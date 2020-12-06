using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Day6
{
    internal class PuzzleOne : IPuzzle
    {
        public string Solve()
        {
            var lines = File.ReadAllLines("Inputs6.txt").ToList();

            var yesTo = new ArrayList();
            int total = 0;

            foreach (var line in lines)
            {
                if (String.IsNullOrEmpty(line.Trim()))
                {
                    int count = yesTo.Count;
                    total += count;
                    yesTo.Clear();
                }
                else
                {
                    foreach (var c in line)
                        if (!yesTo.Contains(c))
                            yesTo.Add(c);
                }
            }
            total += yesTo.Count;
            return total.ToString();
        }
    }
}
