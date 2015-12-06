let rec moveSanta (moves:string) : int =
    let direction = if moves.[0] = '(' then 1 else -1
    if moves.Length = 1 then
        direction
    else        
        moveSanta (moves.Substring 1) + direction

let rec firstBasementMove (moves:string) (floor:int) (count:int) : int=    
    if floor < 0 then count |>ignore 
    let direction = if moves.[0] = '(' then 1 else -1    
    if direction+floor < 0 then count+1 else firstBasementMove (moves.Substring 1) (floor+direction) (count+1)
                 
[<EntryPoint>]
let main argv = 
    let inputLines = System.IO.File.ReadAllLines("input.txt");
    let inputString = inputLines.[0];
    let floor = moveSanta inputString
    let basementMove = firstBasementMove inputString 0 0
    printfn "Santa is at floor: %i" floor
    printfn "Moves to basement: %i" basementMove
    printfn "Press any key to continue..."
    System.Console.ReadLine()
    0 


