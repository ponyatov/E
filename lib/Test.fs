module Test

open Expecto

let tests =
    testList "core" [ //
        test "2+2" { //
            Expect.equal (2 + 2) 4 "2+2 should be 4" } ]

[<EntryPoint>]
let main argv = runTestsWithCLIArgs [] argv tests
