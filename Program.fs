// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

// Define a function to construct a message to print
let from whom =
    sprintf "from %s" whom

[<EntryPoint>]
let main argv =
    let message = from "F#" // Call the function
    printfn "Hello world %s\n" message
    printfn "Enter a character (latin):\n"
    let letter = Char.ToUpper(Convert.ToChar(System.Console.ReadKey))
    match letter with
    |'A' -> printfn "Alfa"
    |'B' -> printfn "Beta"
    |'C' -> printfn "Charlie"
    |'D' -> printfn "Demo"
    |'E' -> printfn "Earth"
    |'F' -> printfn "Force"
    |'G' -> printfn "Gold"
    |'H' ->printfn "Hippi"
    |'I' ->printfn "Item"
    |'J' ->printfn "Java"
    |'K' ->printfn "Kotlin"
    |'L' ->printfn "Lava"
    |'M' ->printfn "Marvel"
    |'N' ->printfn "Navi"
    |'O' ->printfn "Ocean"
    |'P' ->printfn "Python"
    |'Q' ->printfn "Quest"
    |'R' ->printfn "Register"
    |'S' ->printfn "Slava"
    |'T' ->printfn "TypeScript"
    |'U' ->printfn "Unity"
    |'V' ->printfn "Visual"
    |'W' ->printfn "Wall"
    |'X' ->printfn "Xtreme"
    |'Y' ->printfn "Yet"
    |'Z' ->printfn "Zero"
    |_ -> printfn "Not a letter"
    printfn "Enter number:"
    let num = Console.ReadLine() |> int
    let mutable it = 0
    let arr = 
        [|
            1
            2
            3
            4
            5
            6
            7
            8
            9
            0
        |]
    let len = 10
    while it < 10 do
        printf "count elements %d" it
        it <- it + 1
    let mutable n = 15
    for it = 0 to 9 do
        arr.[it] <- it + n
        n <- n - it
    for it = 0 to 9 do
        printfn "%d element is %d" it arr.[it]
    let mutable sum = 0
    for it = 0 to 9 do
        sum <- sum + arr.[it]
    printfn "sum is %d" sum
    let mutable multiplex = 1
    for it = 0 to 9 do
        multiplex <- multiplex*arr.[it]
    printfn "result is %d" multiplex
    printfn "enter your month number:"
    let n = Console.ReadLine()
    match n with
    |"1" -> printfn "January"
    |"2" -> printfn "February"
    |"3" -> printfn "March"
    |"4" -> printfn "April"
    |"5" -> printfn "May"
    |"6" -> printfn "June"
    |"7" -> printfn "July"
    |"8" -> printfn "August"
    |"9" -> printfn "September"
    |"10" -> printfn "October"
    |"11" -> printfn "November"
    |"12" -> printfn "December"
    |_ -> printfn "Not a month"

    printfn "Enter something to exit"
    System.Console.ReadKey()
    System.Console.Clear()
    0 // return an integer exit code