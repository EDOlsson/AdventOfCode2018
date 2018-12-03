module Day1
    let private readInput =
        System.IO.File.ReadAllLines("day1-input", System.Text.Encoding.UTF8)

    let private parseInput input =
        System.Int32.Parse(input, System.Globalization.NumberStyles.AllowLeadingSign)

    let calculateFinalFrequency =
        readInput |> Array.sumBy parseInput

    let private repeateInput input =
        seq { while true do yield! input }

    let private findFrequency n =
        let parsedInput = readInput |> Array.map parseInput

        repeateInput parsedInput
        |> Seq.take n
        |> Seq.fold ( + ) 0

    let private evaluateFrequency (allFrequencies : System.Collections.Generic.HashSet<int>) n =
        let freq = findFrequency n
        let isFrequencyNew = allFrequencies.Add(freq)
        (freq, isFrequencyNew)

    let findFirstRepeatedFrequency =
        let existingFrequencies = new System.Collections.Generic.HashSet<int>()

        repeateInput readInput
         |> Seq.mapi (fun i _ -> evaluateFrequency existingFrequencies i)
         |> Seq.filter (snd >> not)
         |> Seq.head
         |> fst
