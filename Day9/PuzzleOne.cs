using Common;
using System;
using System.IO;
using System.Linq;

namespace Day9
{
    internal class PuzzleOne : IPuzzle
    {

        public string Solve()
        {
            var input = File.ReadAllLines("Inputs9.txt").Select(x => long.Parse(x)).ToList();

            return Calculs.PartOne(input).ToString();
        }
    }
}
