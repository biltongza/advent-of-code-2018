namespace Day2.Part1
open System
open System

module Library =

    let count x xs =
        xs
        |> Seq.filter (fun x' -> x' = x)
        |> Seq.length

    let filterRepeatingCharacters x:string =
        let twoRepeatingMultiple = x |> String.filter(fun c -> (count c x) = 2)
        let threeRepeatingMultiple = x |> String.filter(fun c -> (count c x) = 3)
        let twoRepeating = twoRepeatingMultiple |> String.filter(fun c -> twoRepeatingMultiple.[0] = c)
        let threeRepeating = threeRepeatingMultiple |> String.filter(fun c -> threeRepeatingMultiple.[0] = c)
        twoRepeating + threeRepeating

    let getScore x =
        let count2 = x |> String.exists(fun c -> (count c x) = 2)
        let count3 = x |> String.exists(fun c -> (count c x) = 3)
        ((if count2 then 1 else 0), (if count3 then 1 else 0))

    let sumTuple (a, b)(x, y) =
        (a + x, b + y)

    let calculateChecksum xs =
       let result = xs
                   |> Seq.map(fun x -> filterRepeatingCharacters(x))
                   |> Seq.filter(fun x -> String.IsNullOrEmpty(x) <> true)
                   |> Seq.map(fun x -> getScore x)
                   |> Seq.reduce(fun (x, y)(a, b) -> (x+a, y+b))
       fst(result) * snd(result)
