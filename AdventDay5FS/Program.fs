// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open System.Text.RegularExpressions
open System.IO

let NaughtyNiceV1 input = 
    let failCondition = Regex.IsMatch(input, "(ab|cd|pq|xy)")
    let repeatTwo = Regex.IsMatch(input, @"([a-zA-Z])\1")
    let vowelThree = (Regex.Matches(input, "[aeiou]").Count > 2)
    not failCondition && repeatTwo && vowelThree

let NaughtyNiceV2 input =
    let overlappingPair = Regex.IsMatch(input, @"^.*(?<rpt>([a-zA-Z])\w).*\k<rpt>")
    let repeatBetween = Regex.IsMatch(input, @"^.*(?<rpt>([a-zA-Z])).{1}\k<rpt>")
    overlappingPair && repeatBetween

[<EntryPoint>]
let main argv = 
    let lines = File.ReadLines(@"input.txt");
    
    let niceV1 = 
        lines
            |> Seq.filter( fun s -> NaughtyNiceV1 s)
            |> Seq.length

    let niceV2 = 
        lines
            |> Seq.filter( fun s -> NaughtyNiceV2 s)
            |> Seq.length
   
    printfn "Nice List V1: %i" niceV1
    printfn "Nice List V2: %i" niceV2
    printfn "Press any key to continue..."
    System.Console.ReadLine()
    0 // return an integer exit code
