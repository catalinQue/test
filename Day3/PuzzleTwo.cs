using Common;
using System;

namespace Day3
{
    internal class PuzzleTwo : IPuzzle
    {
        public string Solve()
        {
            var inputs = Inputs.GetInputsValues("3");
            var lines = inputs.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var map = new Map(lines);

            long result = 1;
            result = result * map.CountForSlope(1, 1);
            result = result * map.CountForSlope(3, 1);
            result = result * map.CountForSlope(5, 1);
            result = result * map.CountForSlope(7, 1);
            result = result * map.CountForSlope(1, 2);

            return result.ToString();
        }
    }
}
