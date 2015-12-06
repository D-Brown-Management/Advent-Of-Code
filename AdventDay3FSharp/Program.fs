// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
let moveDir i c = 
    match c with
        | '^' -> (0,1,i)
        | '>' -> (1,0,i)
        | 'v' -> (0,-1,i)
        | '<' -> (-1,0,i)        
        | _ -> (0,0,i)


[<EntryPoint>]
let main argv = 
    let inputLines = System.IO.File.ReadAllLines("input.txt");
    let directions = inputLines.[0];
    
    let numUniqueHouses =
        directions
           |> Seq.mapi moveDir
           |> Seq.scan (fun (x1,y1,ct) (x2,y2,ct2) -> (x1+x2,y1+y2,0)) (0,0,0)
           |> Seq.append [(0,0,0)]
           |> Seq.distinct
           |> Seq.length
              
    let realSantaHouses = 
        directions
            |> Seq.mapi moveDir
            |> Seq.filter( fun (x,y,c) -> c%2=0)
            |> Seq.scan (fun (x1,y1,ct) (x2,y2,ct2) -> (x1+x2,y1+y2,0)) (0,0,0)
      
    let roboSantaHouses = 
        directions
            |> Seq.mapi moveDir
            |> Seq.filter( fun (x,y,c) -> c%2=1)
            |> Seq.scan (fun (x1,y1,ct) (x2,y2,ct2) -> (x1+x2,y1+y2,0)) (0,0,0)      

    let roboUniqueHouses = 
        Seq.append realSantaHouses roboSantaHouses
        |> Seq.append [(0,0,0)]
        |> Seq.distinct
        |> Seq.length

    printfn "Santa visited %i houses solo." numUniqueHouses
    printfn "Santa visited %i houses with his robot." roboUniqueHouses
    printfn "Press any key to continue..."
    System.Console.ReadLine()

    0 // return an integer exit code
