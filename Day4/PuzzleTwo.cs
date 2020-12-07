using Common;
using System;
using System.IO;
using System.Linq;

namespace Day4
{
    internal class PuzzleTwo : IPuzzle
    {
        public string Solve()
        {
            string inputs;
            using (StreamReader sr = new StreamReader("Inputs4.txt"))
            {
                inputs = sr.ReadToEnd();
            }
            var lines = inputs.Split(new[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.None).ToList();

            var passports = Passport.GetPassports(lines);
            passports = Passport.ValidatePassports(passports);

            return passports.Count.ToString();
        }
    }
}
