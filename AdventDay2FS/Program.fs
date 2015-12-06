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
    let fileArray = System.IO.File.ReadLines("input.txt")
    let wallpaperNeeded = getPaper fileArray
    let ribbonNeeded = getRibbon fileArray
    printfn "The elves need %i wallpaper." wallpaperNeeded
    printfn "The elves need %i ribbon." ribbonNeeded
    printfn "Press any key to continue..."
    System.Console.ReadLine()
    0
