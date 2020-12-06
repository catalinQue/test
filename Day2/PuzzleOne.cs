using Common;
using System;

namespace Day2
{
    internal class PuzzleOne : IPuzzle
    {
        public string Solve()
        {
            var inputs = Inputs.GetInputsValues("2");
            var lines = inputs.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var count = 0;

            foreach (var line in lines)
             {             
                 if (PasswordPolicy.ValidateOne(PasswordPolicy.Parse(line))) 
                     count++;
             }
             return count.ToString();
        }
    }
}
