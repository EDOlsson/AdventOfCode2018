// Learn more about F# at http://fsharp.org

open System
open Day1

[<EntryPoint>]
let main argv =
    let day1FinalFrequency = readInput
                             |> Array.sumBy parseInput

    printfn "Day  1 : The final frequency is %d" day1FinalFrequency
    
    0 // return an integer exit code
