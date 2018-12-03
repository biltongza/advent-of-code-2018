namespace Day1.Part2
{
  using System;
  using System.Collections.Generic;
  using System.IO;

  class Program
  {
    static void Main(string[] args)
    {
      var lines = File.ReadAllLines("..\\input.txt");
      HashSet<int> frequencies = new HashSet<int>();
      bool found = false;
      int current = 0;
      while (!found)
      {
        foreach (var line in lines)
        {
          current += int.Parse(line);
          if (frequencies.TryGetValue(current, out int actual))
          {
            found = true;
            Console.WriteLine(current);
            break;
          }
          else
          {
            frequencies.Add(current);
          }
        }
      }
    }
  }
}
