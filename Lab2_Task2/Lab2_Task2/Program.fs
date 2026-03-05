open System

let rec Read_Number () =
    let input = Console.ReadLine()
    let succes, n = Int32.TryParse(input)

    if succes && n > -1 && n < 10 then
        n
    else
        printf "Ошибка: Введена не цифра. Повторите ввод: "
        Read_Number ()

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

let Count_Elem numbers (digit: int) = 
    let Ch = char (int '0' + digit)
    numbers
    |> List.fold (fun count n ->
        if n.ToString().Contains(Ch) then
            count + 1
        else
            count
    ) 0


[<EntryPoint>]
let main arg = 
    let list = Create_list()
    printf "Введите цифру для поиска: "
    let digit = Read_Number()
    let result = Count_Elem list digit

    printfn "Исходный список: %A" list
    printf "Количество чисел, содержащих цифру %i: %i" digit result
    0
