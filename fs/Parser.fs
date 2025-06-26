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
let pA = pchar 'A'

#r "nuget: Expecto, 10.2.3"
open Expecto

testCase "Addition" <| fun _ ->
    Expect.equal (1+1) 2 "1+1=2"

pA ""
"" |> pA
"AB" |> pA
"BC" |> pA

// https://fsharpforfunandprofit.com/posts/understanding-parser-combinators-2/
// https://fsharpforfunandprofit.com/posts/understanding-parser-combinators-3/
// https://fsharpforfunandprofit.com/posts/understanding-parser-combinators-4/
