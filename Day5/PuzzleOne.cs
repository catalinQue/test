using Common;
using System;
using System.IO;
using System.Linq;

namespace Day5
{
    public class PuzzleOne : IPuzzle
    {
        public string Solve()
        {
            var input = from line in File.ReadLines("Inputs5.txt")
                        select Convert.ToInt32(line.Replace("B", "1")
                                                   .Replace("F", "0")
                                                   .Replace("R", "1")
                                                   .Replace("L", "0"), 2);

            var result = input.Max();

            return result.ToString();
        }
    }
}
