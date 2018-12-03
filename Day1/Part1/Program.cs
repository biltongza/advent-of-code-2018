namespace Day1.Part1
{
  using System;
  using System.IO;

  class Program
  {
    static void Main(string[] args)
    {
      var lines = File.ReadAllLines("..\\input.txt");
      int n = 0;
      foreach (var line in lines)
      {
        n += int.Parse(line);
      }
      Console.WriteLine(n);
    }
  }
}
