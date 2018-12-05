namespace Day3.Part1

open Xunit
open Day3.Part1.Library

module Tests =
    [<Fact>]
    let ``parseClaims works``() =
        let input = "#1 @ 1,3: 4x4"
        let expected = {ID= 1; OffsetX=1; OffsetY=3; Width=4; Height=4;}

        let actual = parseClaim input
        Assert.Equal(expected, actual)

    [<Fact>]
    let ``getIntersectingArea``() =
        let input = [
            {ID=1; OffsetX=1; OffsetY=3; Width=4; Height=4;}
            {ID=2; OffsetX=3; OffsetY=1; Width=4; Height=4;}
            {ID=3; OffsetX=5; OffsetY=5; Width=2; Height=2;}
        ]

        let expected = 4
        let actual = getIntersectingArea input
        Assert.Equal(expected, actual)

