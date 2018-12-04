namespace Day2.Part2

open System
open Xunit

module Tests =
    [<Fact>]
    let ``Finds common letters between correct box IDs`` () =
        let input = [
            "abcde";
            "fghij";
            "klmno";
            "pqrst";
            "fguij";
            "axcye";
            "wvxyz"
        ]
        let expected = "fgij"
        let actual = Library.findCommonCharacters input
        Assert.Equal(expected, actual)

