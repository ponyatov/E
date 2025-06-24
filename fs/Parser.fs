//! parser combinators

// https://fsharpforfunandprofit.com/posts/understanding-parser-combinators/
// https://fsharpforfunandprofit.com/posts/understanding-parser-combinators-2/
// https://fsharpforfunandprofit.com/posts/understanding-parser-combinators-3/
// https://fsharpforfunandprofit.com/posts/understanding-parser-combinators-4/

type ParseResult<'a> =
    | Success of 'a
    | Failure of string

let parseA (str: string) =
    match str with
    | "" -> Failure "empty"
    | _ when str.StartsWith 'A' -> Success("A", str.[1..])
    | _ -> Failure str

"" |> parseA
"AB" |> parseA
"BC" |> parseA
