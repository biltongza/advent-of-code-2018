namespace Day3.Part2
open System
open Xunit
open Library
open Day3.Part1.Library

module Tests=
    [<Fact>]
    let ``findLoneClaim works``() =
        let input = [
            {ID=1; OffsetX=1; OffsetY=3; Width=4; Height=4;}
            {ID=2; OffsetX=3; OffsetY=1; Width=4; Height=4;}
            {ID=3; OffsetX=5; OffsetY=5; Width=2; Height=2;}
        ]

        let expectedId = 3
        let actual = findLoneClaim input
        Assert.Equal(expectedId, actual.ID)
