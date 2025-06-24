//! parser combinators

// https://fsharpforfunandprofit.com/posts/understanding-parser-combinators/
// https://fsharpforfunandprofit.com/posts/understanding-parser-combinators-2/
// https://fsharpforfunandprofit.com/posts/understanding-parser-combinators-3/
// https://fsharpforfunandprofit.com/posts/understanding-parser-combinators-4/

let parseA (str: string) : bool * string =
    match str with
    | "" -> (false, "")
    | _ when str.StartsWith 'A' -> (true, str.[1..])
    | _ -> (false, str)

"" |> parseA
"AB" |> parseA
"BC" |> parseA
