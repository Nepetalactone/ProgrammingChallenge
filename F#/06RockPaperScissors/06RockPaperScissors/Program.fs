type Choices = 
| Rock = 0
| Paper = 1
| Scissors = 2

let rec getPlayerChoice () = 
    printfn "Enter your choice"
    match System.Console.ReadLine() with
    | "rock" -> Choices.Rock
    | "paper" -> Choices.Paper
    | "scissors" -> Choices.Scissors
    | _ -> getPlayerChoice ()

let rec game () =
    let playerChoice = getPlayerChoice ()
    let rng = System.Random().Next(0, 3)

    match playerChoice, enum<Choices>(rng) with
        | Choices.Rock, Choices.Rock -> printfn "Tie"
        | Choices.Rock, Choices.Scissors -> printfn "Win"
        | Choices.Rock, Choices.Paper -> printfn "Lose"
        | Choices.Scissors, Choices.Rock -> printfn "Lose"
        | Choices.Scissors, Choices.Scissors -> printfn "Tie"
        | Choices.Scissors, Choices.Paper -> printfn "Win"
        | Choices.Paper, Choices.Rock -> printfn "Win"
        | Choices.Paper, Choices.Scissors -> printfn "Lose"
        | Choices.Paper, Choices.Paper -> printfn "Tie"
        | _, _ -> ()

    game ()

game()

System.Console.ReadKey() |> ignore



