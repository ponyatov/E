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

let pchar (c: char) =
    Parser(fun (s: string) ->
        match s with
        | "" -> Fail s
        | s when s.[0] = c -> Succ(c, s.[1..])
        | _ -> Fail s)

let A = pchar 'A'

run A "" // Fail ""
run A "A" // Succ ('A', "")
run A "B" // Fail "B"
run A "ABC" // Succ ('A', "BC")

let B = pchar 'B'

run B "" // Fail ""
run B "A" // Fail "A"
run B "BC" // Succ ('B', "C")
