using Common;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day10
{
    internal class PuzzleTwo : IPuzzle
    {
        public string Solve()
        {
            int[] lines = File.ReadAllLines("Inputs10.txt").Select(num => int.Parse(num)).ToArray<int>();

            return Calcul(GetAdapters(lines));
        }

        private string Calcul(List<int> items)
        {
            var nbW = new long[items.Count];
            foreach (var index in Enumerable.Range(0, nbW.Length))
            {
                if (index == 0)
                    nbW[index] = 1;
                else
                {
                    nbW[index] = 0;
                    for (var j = index - 1; j >= 0; j--)
                    {
                        if (items[index] - items[j] <= 3)
                            nbW[index] += nbW[j];
                        else
                            break;
                    }
                }
            }
            return (nbW[nbW.Length - 1]).ToString();
        }
        private List<int> GetAdapters(int[] lines)
        {
            var adapters = lines.ToList<int>();
            adapters.Sort();
            adapters.Insert(0, 0);
            adapters.Add(adapters[adapters.Count - 1] + 3);

            return adapters;
        }

    }
}
