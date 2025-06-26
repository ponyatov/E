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
    Parser(fun str ->
        match str with
        | "" -> Failure str
        | s when s.[0] = c -> Success(c, str.[1..])
        | _ -> Failure str)

/// https://fsharpforfunandprofit.com/posts/understanding-parser-combinators/#testing-the-wrapped-function
let A = pchar 'A'

#r "nuget: Expecto"
open Expecto

test "A simple test" {
    let subject = "Hello World"
    Expect.equal subject "Hello World" "Should match"
}
|> runTestsWithCLIArgs [] [||]

/// as now we have Parser's not functions, we need unwrapping runner:
let run parser input =
    let (Parser p) = parser
    p input

run A ""
"" |> run A
"BC" |> run A
"ABC" |> run A

/// https://fsharpforfunandprofit.com/posts/understanding-parser-combinators/#combining-two-parsers-in-sequence
let B = pchar 'B'

/// A >> B
let next p1 p2 =
    fun input ->
        // run parser 1 with input
        let result1 = run p1 input

        match result1 with
        | Failure err -> Failure err // return error
        | Success(value1, remaining1) ->
            let result2 = run p2 remaining1

            match result2 with
            | Failure err -> Failure err
            | Success(val2, rem2) ->
                let combined = (value1, val2)
                Success(combined, rem2)

/// infix version
let (.>>.) = next

// https://fsharpforfunandprofit.com/posts/understanding-parser-combinators-2/
// https://fsharpforfunandprofit.com/posts/understanding-parser-combinators-3/
// https://fsharpforfunandprofit.com/posts/understanding-parser-combinators-4/
