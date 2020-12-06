using Common;
using System;

namespace Day4
{
    internal class PuzzleTwo : IPuzzle
    {
        public string Solve()
        {
            var inputs = Inputs.GetInputsValues("4");
            //var lines = inputs.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            var count = 0;

            var passports = Passport.ParseMany(inputs);
            foreach (var id in passports)
                if (id.Validate())
                    count++;

            return count.ToString();
        }
    }
}
