using Common;
using System;
using System.Linq;

namespace Day3
{
    internal class PuzzleTwo : IPuzzle
    {
        public string Solve()
        {
            var inputs = Inputs.GetInputsValues("3");
            var lines = inputs.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            return new[] { (1, 1), (1, 3), (1, 5), (1, 7), (2, 1) }.Select(x => Tree.Calcutate(x.Item1, x.Item2, lines)).Aggregate(1L, (a, c) => a * c).ToString();
        }
    }
}
