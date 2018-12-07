namespace Day4.Part1
open System
open System.Collections.Generic

module Parser =
    let parseGuardEvents (input:seq<string>) =

        let parseEvent (lastGuardId:int, allEvents:List<GuardEvent>) (time:DateTime, action:string) =
            let trimmedAction = action.Trim()
            let guardIdStart = trimmedAction.IndexOf "#"
            let mutable guardIdEnd = -1
            let mutable guardId = lastGuardId
            if guardIdStart > -1 then
                guardIdEnd <- trimmedAction.IndexOf(" ", guardIdStart)
                guardId <- Int32.Parse trimmedAction.[guardIdStart+1..guardIdEnd]
            let actualActionStartIndex = if guardIdStart = -1 then 0 else guardIdEnd
            let actualAction = trimmedAction.[actualActionStartIndex..].Trim()
            allEvents.Add {Time=time; GuardId=guardId; Action=actualAction}
            guardId

        let sortedInput = input
                            |> Seq.map(function (line:string) ->
                                                    let index = line.IndexOf "]"
                                                    let timeString = line.[1..index-1]
                                                    let time = DateTime.ParseExact(timeString, "yyyy-MM-dd HH:mm", System.Threading.Thread.CurrentThread.CurrentCulture)
                                                    let action = line.[index+1..]
                                                    (time, action))
                            |> Seq.sortBy(fun (time, _) -> time)

        let mutable lastGuardId = 0
        let mutable eventList = new List<GuardEvent>()
        for (time, action) in sortedInput do
            lastGuardId <- parseEvent (lastGuardId, eventList) (time, action)

        eventList


