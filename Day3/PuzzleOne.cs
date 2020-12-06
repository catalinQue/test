using Common;
using System;

namespace Day3
{
    internal class PuzzleOne : IPuzzle
    {
        public string Solve()
        {
            var inputs = Inputs.GetInputsValues("3");
            var lines = inputs.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var map = new Map(lines);

            return map.CountForSlope(3, 1).ToString();

        }
    }
}
