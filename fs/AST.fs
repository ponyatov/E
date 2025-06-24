type AST = 
    | LineComment of string
    | BlockComment of string
    | Shebang of string

type Primitive =
    | Int of int
    | Float of float
