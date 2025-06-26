//! parser combinators

// https://fsharpforfunandprofit.com/posts/understanding-parser-combinators/

/// generic return type every parser function returns
/// https://fsharpforfunandprofit.com/posts/understanding-parser-combinators/#returning-a-successfailure
type ParseResult<'a> =
    | Success of 'a
    | Failure of string

/// common type for any parser function
/// https://fsharpforfunandprofit.com/posts/understanding-parser-combinators/#encapsulating-the-parsing-function-in-a-type
type Parser<'T> = Parser of (string -> ParseResult<'T * string>)

/// parse a single given char
let pchar (c: char) =
    Parser(fun input ->
        match input with
        | "" -> Failure input
        | s when s.[0] = c -> Success(c, input.[1..])
        | _ -> Failure input)

/// https://fsharpforfunandprofit.com/posts/understanding-parser-combinators/#testing-the-wrapped-function
let A = pchar 'A'

/// as now we have Parser's not a functions, we need unwrapping runner:
let run parser input =
    let (Parser p) = parser
    p input

run A ""
run A "BC"
run A "ABC"

/// https://fsharpforfunandprofit.com/posts/understanding-parser-combinators/#combining-two-parsers-in-sequence
let B = pchar 'B'

/// A >> B
let next p1 p2 =
    Parser(fun input ->
        // run parser 1 with input
        match run p1 input with
        | Failure err -> Failure err
        | Success(value1, rest1) ->
            match run p2 rest1 with
            | Failure err -> Failure err
            | Success(value2, rest2) -> Success((value1, value2), rest2))

/// infix version
let (.>>.) = next

/// https://fsharpforfunandprofit.com/posts/understanding-parser-combinators/#testing-andthen
let AB = A .>>. B
run AB ""
run AB "BC"
run AB "ABC"

// https://fsharpforfunandprofit.com/posts/understanding-parser-combinators-2/
// https://fsharpforfunandprofit.com/posts/understanding-parser-combinators-3/
// https://fsharpforfunandprofit.com/posts/understanding-parser-combinators-4/
