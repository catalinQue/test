using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day6
{
    internal class PuzzleTwo : IPuzzle
    {
        public string Solve()
        {
            var lines = File.ReadAllLines("Inputs6.txt").ToList();
            int count = 0;
            int peopleCount = 0;
            Dictionary<char, int> answers = new Dictionary<char, int>();

            foreach (var line in lines)
            {
                if (line == string.Empty)
                {
                    count += answers.Count(x => x.Value == peopleCount);
                    answers = new Dictionary<char, int>();
                    peopleCount = 0;
                    continue;
                }
                foreach (var letter in line)
                {
                    if (answers.ContainsKey(letter))
                    {
                        answers[letter] += 1;
                    }
                    else
                    {
                        answers[letter] = 1;
                    }
                }
                ++peopleCount;
            }

            count += answers.Count(x => x.Value == peopleCount);
            return count.ToString();
        }
    }
}
