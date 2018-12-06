// Learn more about F# at http://fsharp.org
namespace Day3.Part2

open System.IO
open Library

module Program =
    [<EntryPoint>]
    let main argv =
        let input = File.ReadAllLines "../input.txt"
        let claims = input |> Seq.map Day3.Part1.Library.parseClaim |> Seq.toList

        let result = findLoneClaim (claims |> Seq.toList)
        printfn "%A" result
        0 // return an integer exit code
