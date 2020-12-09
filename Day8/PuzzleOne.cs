using Common;
using System;

namespace Day8
{
    internal class PuzzleOne : IPuzzle
    {
        public string Solve()
        {
            var inputs = Inputs.GetInputsValues("8");
            var lines = inputs.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            var program = new Program();

            return program.Execute(lines).ToString();
        }


    }
}
