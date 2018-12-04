namespace Day2.Part1

module Library =
    let filterRepeatingCharacters x:string =
        x

    let count x xs =
        xs
        |> Seq.filter (fun x' -> x' = x)
        |> Seq.length

    let calculateChecksum x =
        0