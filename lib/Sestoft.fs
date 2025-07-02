// Programming Language Concepts for Software Developers
// Peter Sestoft

module Sestoft

open Expecto

type Expr =
    | Int of int
    | BinOp of Op * Expr * Expr
    | Var of string

and Op =
    | Add
    | Mul

type Env = (string * Expr) list
let env: Env = [ ("zero", Int 0) ]

let A = Int 123 // Int 123
let B = Int 456 // Int 456

let ApB = BinOp(Add, A, B) // BinOp (Add, Int 123, Int 456)
let AmB = BinOp(Mul, A, B) // BinOp (Mul, Int 123, Int 456)

let rec eval (e: Expr) (env: Env) : int =
    match e with
    | Int n -> n
    | BinOp(Add, e1, e2) -> eval e1 env + eval e2 env
    | _ -> failwith $"{e}"

eval A // 123
eval B // 456
eval ApB // 579
eval AmB // System.Exception: BinOp

let tests = testList "core" [
    test "none" {
        Expect.equal (2 + 2) 4 "2+2 should be 4"
    }
]

[<EntryPoint>]
let main args = runTestsWithArgs defaultConfig args tests
