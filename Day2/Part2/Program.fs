namespace Day2.Part2
// Learn more about F# at http://fsharp.org

open System
open System.IO
module Program =
    [<EntryPoint>]
    let main argv =
        let input = File.ReadAllLines "../input.txt"

        let result = Library.findCommonCharacters input
        printfn "%s"  result
        0 // return an integer exit code
