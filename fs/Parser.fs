//! parser combinators

// https://fsharpforfunandprofit.com/posts/understanding-parser-combinators/
// https://fsharpforfunandprofit.com/posts/understanding-parser-combinators-2/
// https://fsharpforfunandprofit.com/posts/understanding-parser-combinators-3/
// https://fsharpforfunandprofit.com/posts/understanding-parser-combinators-4/

type ParseResult<'a> =
    | Success of 'a
    | Failure of string

let pchar (c: char) (str: string) =
    match str with
    | "" -> Failure str
    | _ when str.StartsWith c -> Success(c, str.[1..])
    | _ -> Failure str

"" |> pchar 'A'
"AB" |> pchar 'A'
"BC" |> pchar 'A'
