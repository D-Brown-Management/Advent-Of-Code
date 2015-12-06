// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
let getPaper (fileLines:seq<string>) =
    fileLines
    |> Seq.map ( fun s -> s.Split('x') |> Array.map (fun x -> x |> int))
    |> Seq.toList      
    |> List.map(fun (a) -> List.sort [a.[0]*a.[1];a.[0]*a.[2];a.[1]*a.[2]])
    |> List.map(fun(a)->2*a.[0]+2*a.[1]+2*a.[2]+a.[0])       
    |> List.sum 

let getRibbon (fileLines:seq<string>) = 
    fileLines
    |> Seq.map ( fun s -> s.Split('x') |> Array.map (fun x -> x |> int))
    |> Seq.toList      
    |> List.map(fun (a) -> (List.append (List.sort [2*a.[0]+2*a.[1];2*a.[0]+2*a.[2];2*a.[1]+2*a.[2]])) [a.[0]*a.[1]*a.[2]])
    |> List.map(fun (a) -> (a.[0]+a.[3]))
    |> List.sum

[<EntryPoint>]
let main argv = 
    let fileArray = System.IO.File.ReadLines(@"c:\users\steve\desktop\input5.txt")
    let wallpaperNeeded = getPaper fileArray
    let ribbonNeeded = getRibbon fileArray
//    let ary = [ [4;23;21];[22;29;19];[11;4;11];[8;10;5];[24;18;16] ]
//
//    let output =
//        test
//        
    0 // return an integer exit code
