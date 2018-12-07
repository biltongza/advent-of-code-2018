// Learn more about F# at http://fsharp.org
namespace Day4.Part1
open System
open System.IO
open Parser
open Library

module Program =
    [<EntryPoint>]
    let main argv =
        let input = File.ReadAllLines "../input.txt"

        let events = parseGuardEvents input |> Seq.toList
        // let events = [
        //     {Time=new DateTime(1518, 11, 1, 0, 0, 0); GuardId=10; Action="begins shift"}
        //     {Time=new DateTime(1518, 11, 1, 0, 5, 0); GuardId=10; Action="falls asleep"}
        //     {Time=new DateTime(1518, 11, 1, 0, 25, 0); GuardId=10; Action="wakes up"}
        //     {Time=new DateTime(1518, 11, 1, 0, 30, 0); GuardId=10; Action="falls asleep"}
        //     {Time=new DateTime(1518, 11, 1, 0, 55, 0); GuardId=10; Action="wakes up"}
        //     {Time=new DateTime(1518, 11, 1, 23, 58, 0); GuardId=99; Action="begins shift"}
        //     {Time=new DateTime(1518, 11, 2, 0, 40, 0); GuardId=99; Action="falls asleep"}
        //     {Time=new DateTime(1518, 11, 2, 0, 50, 0); GuardId=99; Action="wakes up"}
        //     {Time=new DateTime(1518, 11, 3, 0, 5, 0); GuardId=10; Action="begins shift"}
        //     {Time=new DateTime(1518, 11, 3, 0, 24, 0); GuardId=10; Action="falls asleep"}
        //     {Time=new DateTime(1518, 11, 3, 0, 29, 0); GuardId=10; Action="wakes up"}
        //     {Time=new DateTime(1518, 11, 4, 0, 2, 0); GuardId=99; Action="begins shift"}
        //     {Time=new DateTime(1518, 11, 4, 0, 36, 0); GuardId=99; Action="falls asleep"}
        //     {Time=new DateTime(1518, 11, 4, 0, 46, 0); GuardId=99; Action="wakes up"}
        //     {Time=new DateTime(1518, 11, 5, 0, 3, 0); GuardId=99; Action="begins shift"}
        //     {Time=new DateTime(1518, 11, 5, 0, 45, 0); GuardId=99; Action="falls asleep"}
        //     {Time=new DateTime(1518, 11, 5, 0, 55, 0); GuardId=99; Action="wakes up"}
        // ]
        let result = findLongestSleeper events
        printfn "%i" result
        0 // return an integer exit code
