type Comment =
    | SheBang of string
    | LineComment of string
    | BlockComment of string

/// primitive
type Prim =
    | Int of int
    | Float of float

let A = Int 123 // Int 123
let B = Int 456 // Int 456

/// operator
type Op =
    /// prefix operators:
    /// `+A`
    | Plus of Expr
    /// `-A`
    | Neg of Expr
    /// suffix operators:
    /// `A++`
    | Inc of Expr
    /// `A--`
    | Dec of Expr
    /// infix operators:
    /// `A+B`
    | Add of Expr * Expr
    /// `A-B`
    | Sub of Expr * Expr
    /// `A*B`
    | Mul of Expr * Expr
    /// `A/B`
    | Div of Expr * Expr

/// expression
and Expr =
    | Prim of Prim
    | Op of Op

/// Abstract Syntax Tree
type AST =
    | Comment of Comment
    | Expr of Expr
