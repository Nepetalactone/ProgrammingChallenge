let rng = System.Random()

match rng.Next(0, 2) with 
| 0 -> printfn "Heads"
| 1 -> printfn "Tails"
| _ -> ()
System.Console.ReadKey() |> ignore