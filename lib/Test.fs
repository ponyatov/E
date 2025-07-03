module Test

open Expecto

open Sestoft

[<Tests>]
let tests =
    testList "core" [ //
        testCase "2+2" <| fun _ -> //
            Expect.equal (2 + 2) 4 "2+2 should be 4"
        testCase "A" <| fun _ ->
            let A = Int 123
            Expect.equal A (Int 123)  "A"
        testCase "B" <| fun _ ->
            let B = Int 456
            Expect.equal B (Int 456)  "B"
    ]

// [<EntryPoint>]
// let main argv =
//     runTestsWithCLIArgs [] argv tests
//     runTestsWithArgs defaultConfig argv tests
