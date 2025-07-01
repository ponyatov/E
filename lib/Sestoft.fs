// Programming Language Concepts for Software Developers
// Peter Sestoft


type Expr =
    | Int of int
    | BinOp of Op * Expr * Expr

and Op =
    | Add
    | Mul

let A = Int 123 // Int 123
let B = Int 456 // Int 456

let ApB = BinOp(Add, A, B) // BinOp (Add, Int 123, Int 456)
let AmB = BinOp(Mul, A, B) // BinOp (Mul, Int 123, Int 456)

