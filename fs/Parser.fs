//! parser combinators

// https://fsharpforfunandprofit.com/posts/understanding-parser-combinators/
// https://fsharpforfunandprofit.com/posts/understanding-parser-combinators-2/
// https://fsharpforfunandprofit.com/posts/understanding-parser-combinators-3/
// https://fsharpforfunandprofit.com/posts/understanding-parser-combinators-4/

type ParseResult<'a> =
    | Success of 'a
    | Failure of string

let pchar (c: char) =
    fun (str: string) ->
        match str with
        | "" -> Failure str
        | s when s.[0] = c -> Success(c, str.[1..])
        | _ -> Failure str

let pA = pchar 'A'
"" |> pA
"AB" |> pA
"BC" |> pA
