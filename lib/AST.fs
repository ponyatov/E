//! E language syntax tree types
module AST

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

/// [sestoft]
let rec eval (expr: Expr) : int =
    match expr with
    | Prim(Int n) -> n
    | Prim(Float f) -> System.Convert.ToInt32(f)
    | _ -> failwith $"{expr}"

Prim(Int 123) |> eval // 123
Prim(Float 12.34) |> eval // 12
Prim(Float -3e+4) |> eval // -30000
