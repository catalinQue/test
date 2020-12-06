using Common;
using System;

namespace Day2
{
    internal class PuzzleTwo : IPuzzle
    {
        public string Solve()
        {
            var inputs = Inputs.GetInputsValues("2");

            var lines = inputs.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var count = 0;

            foreach (var line in lines)
            {
                if (PasswordPolicy.ValidateTwo(PasswordPolicy.Parse(line.Trim())))
                    count++;
            }
            return count.ToString();
        }
    }
}
