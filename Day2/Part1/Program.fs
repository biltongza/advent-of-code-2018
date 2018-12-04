open System
open Day2.Part1
module Program =
    let [<EntryPoint>] main argv =
      let text = "hello world"
      let ch = 'l'
      printfn "%d" (Library.count ch text)

      Console.ReadLine() |> ignore
      0