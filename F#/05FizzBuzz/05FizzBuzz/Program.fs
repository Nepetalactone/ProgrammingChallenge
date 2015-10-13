for i in [0..100] do
    match i%5, i%3 with
    | 0, 0 -> printfn "FizzBuzz"
    | 0, _ -> printfn "Fizz"
    | _, 0 -> printfn "Buzz"
    | _, _ -> printfn "%A" i

System.Console.ReadKey() |> ignore