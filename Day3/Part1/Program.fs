// Learn more about F# at http://fsharp.org
namespace Day3.Part1

open Library
open System.IO

module Program =
    [<EntryPoint>]
    let main argv =
        let input = File.ReadAllLines("../input.txt")
        let claims = input |> Seq.map parseClaim |> Seq.toList

        let result = getIntersectingArea claims
        printfn "%i" result

        0 // return an integer exit code
