namespace Day4.Part1
open System
open System.Collections.Generic
open Xunit
open Parser
open Library
module Tests=

    [<Fact>]
    let ``parsing works`` () =
        let input = [
            "[1518-11-01 00:00] Guard #10 begins shift"
            "[1518-11-01 00:05] falls asleep"
            "[1518-11-01 00:25] wakes up"
            "[1518-11-01 00:30] falls asleep"
            "[1518-11-01 00:55] wakes up"
            "[1518-11-01 23:58] Guard #99 begins shift"
            "[1518-11-02 00:40] falls asleep"
            "[1518-11-02 00:50] wakes up"
            "[1518-11-03 00:05] Guard #10 begins shift"
        ]
        let expected = [
            {Time=new DateTime(1518, 11, 1, 0, 0, 0); GuardId=10; Action="begins shift"}
            {Time=new DateTime(1518, 11, 1, 0, 5, 0); GuardId=10; Action="falls asleep"}
            {Time=new DateTime(1518, 11, 1, 0, 25, 0); GuardId=10; Action="wakes up"}
            {Time=new DateTime(1518, 11, 1, 0, 30, 0); GuardId=10; Action="falls asleep"}
            {Time=new DateTime(1518, 11, 1, 0, 55, 0); GuardId=10; Action="wakes up"}
            {Time=new DateTime(1518, 11, 1, 23, 58, 0); GuardId=99; Action="begins shift"}
            {Time=new DateTime(1518, 11, 2, 0, 40, 0); GuardId=99; Action="falls asleep"}
            {Time=new DateTime(1518, 11, 2, 0, 50, 0); GuardId=99; Action="wakes up"}
            {Time=new DateTime(1518, 11, 3, 0, 5, 0); GuardId=10; Action="begins shift"}
        ]
        let actual = parseGuardEvents input
        Assert.Equal(expected, actual)

    [<Fact>]
    let ``findLongestSleeper works``() =
        let input = [
            {Time=new DateTime(1518, 11, 1, 0, 0, 0); GuardId=10; Action="begins shift"}
            {Time=new DateTime(1518, 11, 1, 0, 5, 0); GuardId=10; Action="falls asleep"}
            {Time=new DateTime(1518, 11, 1, 0, 25, 0); GuardId=10; Action="wakes up"}
            {Time=new DateTime(1518, 11, 1, 0, 30, 0); GuardId=10; Action="falls asleep"}
            {Time=new DateTime(1518, 11, 1, 0, 55, 0); GuardId=10; Action="wakes up"}
            {Time=new DateTime(1518, 11, 1, 23, 58, 0); GuardId=99; Action="begins shift"}
            {Time=new DateTime(1518, 11, 2, 0, 40, 0); GuardId=99; Action="falls asleep"}
            {Time=new DateTime(1518, 11, 2, 0, 50, 0); GuardId=99; Action="wakes up"}
            {Time=new DateTime(1518, 11, 3, 0, 5, 0); GuardId=10; Action="begins shift"}
            {Time=new DateTime(1518, 11, 3, 0, 24, 0); GuardId=10; Action="falls asleep"}
            {Time=new DateTime(1518, 11, 3, 0, 29, 0); GuardId=10; Action="wakes up"}
            {Time=new DateTime(1518, 11, 4, 0, 2, 0); GuardId=99; Action="begins shift"}
            {Time=new DateTime(1518, 11, 4, 0, 36, 0); GuardId=99; Action="falls asleep"}
            {Time=new DateTime(1518, 11, 4, 0, 46, 0); GuardId=99; Action="wakes up"}
            {Time=new DateTime(1518, 11, 5, 0, 3, 0); GuardId=99; Action="begins shift"}
            {Time=new DateTime(1518, 11, 5, 0, 45, 0); GuardId=99; Action="falls asleep"}
            {Time=new DateTime(1518, 11, 5, 0, 55, 0); GuardId=99; Action="wakes up"}
        ]
        let expected = 240
        let actual = findLongestSleeper input
        Assert.Equal(expected, actual)

