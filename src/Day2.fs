module Day2
    open System
    let readInput =
        System.IO.File.ReadAllLines("day2-input", System.Text.Encoding.UTF8)

    type BoxIdClassification = 
         | HasTwoLetters
         | HasThreeLetters
         | HasTwoAndThreeLetters
         | DontCare

    let private classifyBoxId (boxId : string) =
        let hasRepeatedLetters (boxId' : string) count =
            let repeated = boxId'.ToCharArray()
                            |> Array.groupBy id
                            |> Array.map (fun pair -> (snd pair).Length)
                            |> Array.filter (fun len -> len = count)
            repeated.Length > 0

        match (hasRepeatedLetters boxId 2, hasRepeatedLetters boxId 3) with
        | (true, true) -> HasTwoAndThreeLetters
        | (true, false) -> HasTwoLetters
        | (false, true) -> HasThreeLetters
        | _-> DontCare

    let calculateChecksum input =
        let matchingBoxIds = input
                             |> Array.map classifyBoxId
                             |> Array.filter (fun c -> c <> DontCare)

        let twoLetters = matchingBoxIds
                         |> Array.filter (fun c -> c = HasTwoLetters)
                         |> Array.length

        let twoAndThreeLetters = matchingBoxIds
                                 |> Array.filter (fun c -> c = HasTwoAndThreeLetters)
                                 |> Array.length

        let threeLetters = matchingBoxIds
                           |> Array.filter (fun c -> c = HasThreeLetters)
                           |> Array.length

        (twoLetters + twoAndThreeLetters) * (twoAndThreeLetters + threeLetters)

    let private compareTwoBoxIds (boxId1 : string) (boxId2 : string) =
        boxId1.ToCharArray()
        |> Array.fold2 (fun s c1 c2 -> if c1 = c2 then Array.append s [|c1|] else s) Array.empty (boxId2.ToCharArray())
        |> System.String.Concat

    let private compareBoxIdWithOtherBoxIds (allBoxIds : string[]) (boxId : string) =
        allBoxIds
        |> Array.filter (fun b -> b <> boxId)
        |> Array.map (compareTwoBoxIds boxId)
        |> Array.maxBy String.length

    let findSimilarBoxIds allBoxIds =
        allBoxIds
        |> Array.map (compareBoxIdWithOtherBoxIds allBoxIds)
        |> Array.maxBy String.length
