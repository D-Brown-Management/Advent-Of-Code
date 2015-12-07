// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open System.Text.RegularExpressions
open System.IO

let santaInstructions lines =
    lines
        |> Seq.map ( fun s -> Regex.Match(s, @"^(?<instruction>turn on|turn off|toggle)\s(?<coord1>\d{1,3},\d{1,3})\s(through)\s(?<coord2>\d{1,3},\d{1,3})").Groups |> ( fun m -> (m.["instruction"].Value, m.["coord1"].Value.Split(',') |> (fun z -> (int z.[0],int z.[1])), m.["coord2"].Value.Split(',') |> (fun z -> (int z.[0],int z.[1])))))
        |> Seq.map ( fun (i, a, b) -> (i, (min (fst a) (fst b), min (snd a) (snd b)), (max (fst a) (fst b), max (snd a) (snd b))))
    

let v1Test operation (x1, y1) (x2, y2) lightAry =
    
    for i in x1..x2 do
        for j in y1..y2 do
            match operation with
                | "turn on" -> Array2D.set lightAry i j true
                | "turn off" -> Array2D.set lightAry i j false
                | "toggle" -> Array2D.set lightAry i j (not lightAry.[i,j])
    
    lightAry
    
let v2Test operation (x1, y1) (x2, y2) lightAry =
    
    for i in x1..x2 do
        for j in y1..y2 do
            match operation with
                | "turn on" -> Array2D.set lightAry i j (lightAry.[i,j]+1)
                | "turn off" -> Array2D.set lightAry i j (if lightAry.[i,j] = 0 then 0 else lightAry.[i,j]-1)
                | "toggle" -> Array2D.set lightAry i j (lightAry.[i,j]+2)
    
    lightAry   


[<EntryPoint>]
let main argv = 
    let fileArray = File.ReadLines("input.txt")
    let instr = santaInstructions fileArray
    let lightAry = Array2D.create 1000 1000 false
    let v2LightAry = Array2D.create 1000 1000 0

    let v1Count =   
        instr
            |> Seq.fold ( fun a (op, (x,y), (x2,y2)) -> (v1Test op (x,y) (x2, y2) a)) lightAry 
            |> Seq.cast |> Seq.filter id |> Seq.length  
  
    let v2Result = 
        instr
            |> Seq.fold ( fun a (op, (x,y), (x2,y2)) -> (v2Test op (x,y) (x2, y2) a)) v2LightAry  
            |> Seq.cast<int> |> Seq.sum  
            //|> Seq.fold (fun (op, (x,y), (x2,y2)) -> v1Test op (x,y) (x2, y2) lightAry)
            
    printfn "Santa's first light count %i." v1Count
    printfn "Santa's second light intensity %i." v2Result
    printfn "Press any key to continue..."
    System.Console.ReadLine()
    0 // return an integer exit code
     