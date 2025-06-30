type Comment =
    | SheBang of string
    | LineComment of string
    | BlockComment of string

/// primitive
type Prim =
    | Int of int
    | Float of float

/// operator
type Op =
    | Add of Expr * Expr
    | Sub of Expr * Expr
    | Mul of Expr * Expr
    | Div of Expr * Expr

/// expression
and Expr =
    | Prim of Prim
    | Op of Op

/// Abstract Syntax Tree
type AST =
    | Comment of Comment
    | Expr of Expr
