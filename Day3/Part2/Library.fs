namespace Day3.Part2
open Day3.Part1.Library

module Library =

    let findLoneClaim claims =

        let intersects a b =
            (a.OffsetX + a.Width > b.OffsetX) &&
            (b.OffsetX + b.Width > a.OffsetX) &&
            (a.OffsetY + a.Height > b.OffsetY) &&
            (b.OffsetY + b.Height > a.OffsetY)

        claims
        |> Seq.filter (fun item ->
                        claims
                        |> Seq.filter(fun element -> element <> item)
                        |> Seq.forall(fun other -> not (intersects item other)))
        |> Seq.head




