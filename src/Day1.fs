module Day1
    let readInput =
        System.IO.File.ReadAllLines("day1-input", System.Text.Encoding.UTF8)

    let parseInput input =
        System.Int32.Parse(input, System.Globalization.NumberStyles.AllowLeadingSign)

    let continuousInput =
        let singleInput = readInput |> Array.map parseInput

        seq { while true do yield! singleInput }

    let findFrequency n =
        continuousInput
        |> Seq.take n
        |> Seq.fold ( + ) 0

    let evaluateFrequency (allFrequencies : System.Collections.Generic.HashSet<int>) n =
        let freq = findFrequency n
        let isFrequencyNew = allFrequencies.Add(freq)
        (freq, isFrequencyNew)
