// https://fsharpforfunandprofit.com/posts/understanding-parser-combinators/

/// parser result
type PResult<'T> =
    /// successfully parsed
    | Succ of 'T
    /// syntax error
    | Fail of string

/// generic parser
type Parser<'T> = Parser of (string -> 'T * string)

/// helper function to run typed combinators
let run (Parser p) input = p input
