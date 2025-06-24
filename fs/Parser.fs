//! parser combinators

// https://fsharpforfunandprofit.com/posts/understanding-parser-combinators/
// https://fsharpforfunandprofit.com/posts/understanding-parser-combinators-2/
// https://fsharpforfunandprofit.com/posts/understanding-parser-combinators-3/
// https://fsharpforfunandprofit.com/posts/understanding-parser-combinators-4/

/// generic return type every parser function returns
type ParseResult<'a> =
    | Success of 'a
    | Failure of string

/// common type for any parser function
type Parser<'T> = Parser of (string -> ParseResult<'T * string>)

/// parse a single given char
/// @returns 
let pchar (c: char) =
    Parser(fun str ->
        match str with
        | "" -> Failure str
        | s when s.[0] = c -> Success(c, str.[1..])
        | _ -> Failure str)

let pA = pchar 'A'
pA ""
"" |> pA
"AB" |> pA
"BC" |> pA
