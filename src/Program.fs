// Learn more about F# at http://fsharp.org

open System
open Day2

[<EntryPoint>]
let main argv =
    // let day1FinalFrequency = Day1.readInput
    //                          |> Array.sumBy Day1.parseInput

    // printfn "Day  1 : The final frequency is %d" day1FinalFrequency

    // let allFrequencies = new System.Collections.Generic.HashSet<int>()

    // let firstRepeatedFrequency = Day1.continuousInput
    //                              |> Seq.mapi (fun i _ -> Day1.evaluateFrequency allFrequencies i)
    //                              |> Seq.filter (snd >> not)
    //                              |> Seq.head

    // printfn "Day  1 : The first repeated frequency is %d" (fst firstRepeatedFrequency)

    let checksum = Day2.readInput
                   |> calculateChecksum

    printfn "Day  2 : The checksum is %d" checksum
    
    0 // return an integer exit code
