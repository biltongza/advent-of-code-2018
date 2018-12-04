open System
open System.IO
open Day2.Part1
module Program =
    let [<EntryPoint>] main argv =
      let input = File.ReadAllLines("..\input.txt")
      let checksum = Library.calculateChecksum(input);
      printfn "%i" checksum
      0