// Learn more about F# at http://fsharp.org

open System
open Day1

[<EntryPoint>]
let main argv =
    let day1FinalFrequency = readInput
                             |> Array.sumBy parseInput

    printfn "Day  1 : The final frequency is %d" day1FinalFrequency

    let allFrequencies = new System.Collections.Generic.HashSet<int>()

    let firstRepeatedFrequency = continuousInput
                                 |> Seq.mapi (fun i _ -> evaluateFrequency allFrequencies i)
                                 |> Seq.filter (snd >> not)
                                 |> Seq.head

    printfn "Day  1 : The first repeated frequency is %d" (fst firstRepeatedFrequency)
    
    0 // return an integer exit code
