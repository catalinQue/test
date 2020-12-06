using Common;
using System;

namespace Day4
{
    internal class PuzzleOne : IPuzzle
    {
        public string Solve()
        {
            var inputs = Inputs.GetInputsValues("4");
            var lines = inputs.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            var count = 0;

            var passports = Passport.ParseMany(inputs);
            foreach (var id in passports)
                if (id.ContainsRequiredFields)
                    count++;

            return count.ToString();
        }
    }
}
