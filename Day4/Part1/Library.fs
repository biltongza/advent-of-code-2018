namespace Day4.Part1
open System

module Library=
    let findLongestSleeper guardEvents =

        let longestSleeperFolder (sum:float, lastAsleep:DateTime) (event:GuardEvent) =
            match event.Action with
            | "falls asleep" -> (sum, event.Time)
            | "wakes up" -> (sum + (event.Time - lastAsleep).TotalMinutes, lastAsleep)
            | _ -> (sum, lastAsleep)

        let minuteExpander (lastAsleep, minutes) event =
            match event.Action with
            | "falls asleep" -> (event.Time, minutes)
            | "wakes up" -> (lastAsleep, Seq.append minutes [lastAsleep.Minute..event.Time.Minute-1])
            | _ -> (lastAsleep, minutes)

        let sumSleepTime =
            guardEvents
            |> Seq.groupBy(fun e -> e.GuardId)
            |> Seq.map(fun (guardId, events) ->
                                    let (timeAsleep, _)= events |> Seq.fold longestSleeperFolder (0.0, new DateTime())
                                    (guardId, timeAsleep, events))
            |> Seq.toList
        let guardId, _, events = sumSleepTime |> Seq.maxBy (fun (_, timeAsleep, _) -> timeAsleep)
        let _, minutes = events |> Seq.fold minuteExpander (new DateTime(), Seq.empty)
        let groupedMinutes = minutes |> Seq.groupBy(fun m -> m) |> Seq.map (fun (minute, minutes) -> (minute, Seq.length minutes)) |> Seq.toList
        let mostCommonMinute, _ =  groupedMinutes |> Seq.maxBy(fun (_, count) -> count)
        mostCommonMinute * guardId
