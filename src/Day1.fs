module Day1
    let readInput =
        System.IO.File.ReadAllLines("day1-input", System.Text.Encoding.UTF8)

    let parseInput input =
        System.Int32.Parse(input, System.Globalization.NumberStyles.AllowLeadingSign)
