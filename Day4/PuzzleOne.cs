using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day4
{
    internal class PuzzleOne : IPuzzle
    {
        public string Solve()
        {
            string inputs;
            using (StreamReader sr = new StreamReader("Inputs4.txt"))
            {
                inputs = sr.ReadToEnd();
            }
            var lines = inputs.Split(new[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.None).ToList();

            return Passport.GetPassports(lines).Count.ToString();
        }
    }
}
