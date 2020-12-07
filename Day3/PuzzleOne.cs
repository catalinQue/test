using Common;
using System;
using System.Linq;

namespace Day3
{
    internal class PuzzleOne : IPuzzle
    {
        public string Solve()
        {
            var inputs = Inputs.GetInputsValues("3");
            var lines = inputs.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            return Tree.Calcutate(1, 3, lines).ToString();
        }
    }
}
