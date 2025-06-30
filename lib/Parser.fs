//! parser combinators written from scratch
//! - tabbed syntax parsing
//! - more informative errors
//! - able to parse context-sensitive subgrammars
module Parser

// https://fsharpforfunandprofit.com/posts/understanding-parser-combinators/

/// parser result
type PResult<'T> =
    /// successfully parsed
    | Succ of 'T
    /// syntax error
    | Fail of string

/// generic parser
type Parser<'T> = Parser of (string -> PResult<'T * string>)

/// helper function to run typed combinators
let run (Parser p) (input: string) = p input

/// parse single char
let pchar (c: char) =
    Parser(fun (input: string) ->
        match input with
        | "" -> Fail input
        | input when input.[0] = c -> Succ(c, input.[1..])
        | _ -> Fail input)

let A = pchar 'A'

run A "" // Fail ""
run A "A" // Succ ('A', "")
run A "B" // Fail "B"
run A "ABC" // Succ ('A', "BC")

let B = pchar 'B'

run B "" // Fail ""
run B "A" // Fail "A"
run B "BC" // Succ ('B', "C")

/// parse string
let pstr (s: string) =
    Parser(fun (input: string) ->
        match input with
        | "" -> Fail input
        | input when input.StartsWith(s) -> Succ(s, input.[s.Length ..])
        | _ -> Fail input)

let LineCommentPfx = pstr "//"

run LineCommentPfx "" // Fail ""
run LineCommentPfx "//" // Succ ("//", "")
run LineCommentPfx "// A\n//" // Succ ("//", " A\n//")

// https://fsharpforfunandprofit.com/posts/understanding-parser-combinators/#combining-two-parsers-in-sequence

/// combine two parsers in sequence
let (>>) p1 p2 =
    Parser(fun (input: string) ->
        match run p1 input with
        | Fail err -> Fail err // pass error
        | Succ(val1, rest1) ->
            match run p2 rest1 with
            | Fail err -> Fail err
            | Succ(val2, rest2) -> //
                Succ((val1, val2), rest2))

let AB = A >> B

run AB "" // Fail ""
run AB "A" // Fail ""
run AB "AB" // Succ (('A', 'B'), "")
run AB "ABC" // Succ (('A', 'B'), "C")

/// parse until given char found (treated as delimiter)
let uchar (c: char) =
    Parser(fun input ->
        if input = "" then
            Fail input // empty string
        else
            let index = input.IndexOf(c)

            if index = -1 then
                Fail input
            else
                let result = input.[0 .. index - 1] // Everything before the c
                let rest = input.[index + 1 ..] // remaining input
                Succ(result, rest))

let uA = uchar 'A'
run uA "" // Fail ""
run uA "A" // Succ ("", "")
run uA "AB" // Succ ("", "B")

/// parse into AST::LineComment
let pLineComment =
    Parser(fun input ->
        match run (pstr "//") input with // skip prefix
        | Fail err -> Fail err
        | Succ(_, rest1) ->
            match run (uchar '\n') rest1 with
            | Fail err -> Fail err
            | Succ(comment, rest2) -> // wrap comment text
                Succ(LineComment comment, rest2))

run pLineComment "" // Fail ""
run pLineComment "//" // Fail "" no end of line
run pLineComment "//\nABC" // Succ (("//", ""), "ABC") empty comment
run pLineComment "//AB\nC" // Succ (("//", "AB"), "C")
