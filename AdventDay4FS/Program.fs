let santaMd5 (inputString:string) =
    let md5 = System.Security.Cryptography.MD5Cng()    
    let inputBytes = System.Text.Encoding.ASCII.GetBytes(inputString)
    let outputBytes = md5.ComputeHash(inputBytes)    
    System.BitConverter.ToString(outputBytes).Replace("-", "")    

let santaHashV1 prefix = 
    seq {0..1000000000} 
    |> Seq.tryFindIndex (fun i -> (santaMd5 (sprintf "%s%i" prefix i)).[0..4] = "00000")
    
let santaHashV2 prefix = 
    seq {0..1000000000} 
        |> Seq.tryFindIndex (fun i -> (santaMd5 (sprintf "%s%i" prefix i)).[0..5] = "000000")
    
[<EntryPoint>]
let main argv = 
    let prefix = "yzbqklnj"

    printfn "Santa's first number %i." (santaHashV1 prefix).Value
    printfn "Santa's second number %i." (santaHashV2 prefix).Value
    printfn "Press any key to continue..."
    System.Console.ReadLine()

    0 // return an integer exit code
