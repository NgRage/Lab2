open System

let rec Read_Natural () =
    let input = Console.ReadLine()
    let succes, n = Int32.TryParse(input)

    if succes && n > 0 then
        n
    else
        printf "Ошибка: Число не натуральное. Повторите ввод: "
        Read_Natural ()

let Create_list () = 
    printf "Введите количество элементов списка: "
    let n = Read_Natural()

    List.init n (fun i ->
        printf "Введите элемент %d: " (i+1)
        Read_Natural()
    )

let Create_Min (numbers: int list) =
    numbers 
    |> List.map (fun n -> 
        n.ToString()
        |> Seq.min
        |> fun c -> int c - int '0'
    )


[<EntryPoint>]
let main arg = 
    let list = Create_list()
    let result = Create_Min list

    printfn "Исходный список: %A" list
    printf "Список минимальных цифр: %A" result
    0
