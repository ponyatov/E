module Test

open Expecto

[<Tests>]
let tests =
    testList
        "core"
        [ //
          testCase "2+2"
          <| fun _ -> //
              Expect.equal (2 + 2) 4 "2+2 should be 4" ]

// [<EntryPoint>]
// let main argv = runTestsWithCLIArgs [] argv tests
