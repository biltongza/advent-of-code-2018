namespace Day2.Part1

open System
open Xunit

module Tests =
    [<Fact>]
    let ``abcdef contains no letters that appear exactly two or three times``() =
        let expected = String.Empty
        let actual = Library.filterRepeatingCharacters "abcdef"
        Assert.Equal<String>(expected, actual)

    [<Fact>]
    let ``bababc contains two a and three b so it counts for both``() =
        let expected = "aabbb"
        let actual = Library.filterRepeatingCharacters "bababc"
        Assert.Equal<String>(expected, actual)

    [<Fact>]
    let ``abbcde contains two b but no letter appears exactly three times``() =
        let expected = "bb"
        let actual = Library.filterRepeatingCharacters "abbcde"
        Assert.Equal<String>(expected, actual)

    [<Fact>]
    let ``abcccd contains three c but no letter appears exactly two times``() =
        let expected = "ccc"
        let actual = Library.filterRepeatingCharacters "abcccd"
        Assert.Equal<String>(expected, actual)

    [<Fact>]
    let ``aabcdd contains two a and two d but it only counts once``() =
        let expected = "aa"
        let actual = Library.filterRepeatingCharacters "aabcdd"
        Assert.Equal<String>(expected, actual)

    [<Fact>]
    let ``abcdee contains two e``() =
        let expected = "ee"
        let actual = Library.filterRepeatingCharacters "abcdee"
        Assert.Equal<String>(expected, actual)

    [<Fact>]
    let ``ababab contains three a and three b but it only counts once``() =
        let expected = "aaa"
        let actual = Library.filterRepeatingCharacters "ababab"
        Assert.Equal<String>(expected, actual)

    [<Fact>]
    let ``calculateChecksum works``() =
        let input = [
            "abcdef";
            "bababc";
            "abbcde";
            "abcccd";
            "aabcdd";
            "abcdee";
            "ababab"
        ]
        let expected = 12
        let actual = Library.calculateChecksum input
        Assert.Equal<int>(expected, actual)