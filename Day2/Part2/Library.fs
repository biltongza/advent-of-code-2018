namespace Day2.Part2

module Library =
    let findCommonCharacters(xs:seq<string>) =

        let different(s:string) i c = s.[i] = c
        let similar(s:string) i c = s.[i] <> c
        let firstHalf(x:string) = x.[0..(x.Length-1)/2]
        let secondHalf(x:string) = x.[((x.Length-1)/2)+1..x.Length-1]

        let compare (x:string, y:string) (comparer) =
            let s1, s2 = x.PadRight(y.Length), y.PadRight(x.Length)
            let result = s1
                         |> String.mapi(fun i c -> if comparer s2 i c then '-' else c )
                         |> String.filter(fun c -> c <> '-')
            result

        let extractCandidates projection (sub:seq<string>) =
            sub
            |> Seq.groupBy projection
            |> Seq.filter(fun (_, values) -> Seq.length values = 2)
            |> Seq.map(fun (_, values) -> (Seq.head values, Seq.last values))
            |> Seq.filter(fun x -> String.length(compare x different) = 1)

        let firstHalfCandidates =  xs |> extractCandidates firstHalf |> Seq.toArray
        let secondHalfCandidates = xs |> extractCandidates secondHalf |> Seq.toArray

        let result = firstHalfCandidates
                        |> Seq.append secondHalfCandidates
                        |> Seq.head

        compare result similar
