using Common;
using System;
using System.IO;
using System.Linq;

namespace Day5
{
    internal class PuzzleTwo : IPuzzle
    {
        public string Solve()
        {

            var input = from line in File.ReadLines("Inputs5.txt")
                        select Convert.ToInt32(line.Replace("B", "1")
                                                   .Replace("F", "0")
                                                   .Replace("R", "1")
                                                   .Replace("L", "0"), 2);

            var min = input.Min();
            var max = input.Max();

            var result = ((max + 1) * max - (min - 1) * min) / 2 - input.Sum();

            return result.ToString();
        }
    }
}
