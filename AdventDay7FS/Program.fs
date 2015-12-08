// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open System.IO
open System.Text.RegularExpressions

let (|AndOrType|_|) input = 
    let m = Regex.Match(input, @"^(?<in1>[a-z0-9]{1,6})\s(?<op>OR|AND)\s(?<in2>[a-z0-9]{1,6})\s->\s(?<dest>[a-z]{1,6})$")
    if(m.Success) then Some m.Groups else None

let (|ShiftType|_|) input = 
    let m = Regex.Match(input, @"^(?<in1>[a-z0-9]{1,6})\s(?<op>RSHIFT|LSHIFT)\s(?<amt>[0-9]{1,6})\s->\s(?<dest>[a-z]{1,6})$")
    if(m.Success) then Some m.Groups else None

let (|NotType|_|) input = 
    let m = Regex.Match(input, @"^(?<op>NOT)\s(?<in1>[a-z]{1,6})\s->\s(?<dest>[a-z]{1,6})$$")
    if(m.Success) then Some m.Groups else None

let (|StaticType|_|) input = 
    let m = Regex.Match(input, @"^(?<in1>[a-z0-9]{1,6})\s->\s(?<dest>[a-z]{1,6})$")
    if(m.Success) then Some m.Groups else None
//
//let getRowType input = 
//    match input with 
//    | AndOrType input -> output
//    | ShiftType input -> output
//    | NotType input -> output
//    | StaticType input -> output

[<EntryPoint>]
let main argv = 
    let fileArray = File.ReadLines("input.txt")

    //let rows = fileArray |> Seq.map getRowType

    printfn "%A" argv
    0 // return an integer exit code
