module Day2

    let readInput =
        System.IO.File.ReadAllLines("day2-input", System.Text.Encoding.UTF8)

    type BoxIdClassification = 
         | HasTwoLetters
         | HasThreeLetters
         | HasTwoAndThreeLetters
         | DontCare

    let classifyBoxId (boxId : string) =
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