type Comment =
    | SheBang of string
    | LineComment of string
    | BlockComment of string

/// primitive
type Prim =
    | Int of int
    | Float of float

/// Abstract Syntax Tree
type AST =
    | Comment of Comment
    | Prim of Prim
