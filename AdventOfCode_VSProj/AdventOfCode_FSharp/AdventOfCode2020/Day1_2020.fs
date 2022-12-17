module Day1_2020

let numbers =
    [1721;
    979;
    366;
    299;
    675;
    1456]

let twoSum lst target =
    []

let runDay1_2020 =
    let answer = twoSum numbers 2020
    printfn "%d" (match answer with a::_ -> a | [] -> 0)