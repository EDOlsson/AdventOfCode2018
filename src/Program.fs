// Learn more about F# at http://fsharp.org

open System
open Day2

[<EntryPoint>]
let main argv =
    let day1FinalFrequency = Day1.calculateFinalFrequency

    printfn "Day  1 : The final frequency is %d" day1FinalFrequency

    let firstRepeatedFrequency = Day1.findFirstRepeatedFrequency

    printfn "Day  1 : The first repeated frequency is %d" firstRepeatedFrequency

    let checksum = Day2.readInput
                   |> calculateChecksum

    printfn "Day  2 : The checksum is %d" checksum

    let answer = Day2.readInput |> Day2.findSimilarBoxIds

    printfn "Day  2 : The matching chars are %s" answer

    0 // return an integer exit code
