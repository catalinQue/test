using Common;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day9
{
    internal class PuzzleTwo : IPuzzle
    {


        public string Solve()
        {
            var lines = File.ReadAllLines("Inputs9.txt").Select(x => long.Parse(x)).ToList();

            return Calculs.PartTwo(lines).ToString();


 
            return "";
        }




    }
}
