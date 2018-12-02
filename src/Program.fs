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
    
    0 // return an integer exit code
