type AST = 
    | LineComment of string
    | BlockComment of string
    | Shebang of string
    | AnyChar of char
    | NewLine

type Primitive =
    | Int of int
    | Float of float
