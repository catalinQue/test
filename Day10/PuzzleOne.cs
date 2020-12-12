using Common;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day10
{
    internal class PuzzleOne : IPuzzle
    {
        public string Solve()
        {
            var lines = File.ReadAllLines("Inputs10.txt").Select(num => int.Parse(num)).ToArray<int>();

            return Calcul(GetAdapters(lines));
        }

        private string Calcul(List<int> items)
        {
            var one = 0;
            var three = 0;
            foreach (var i in Enumerable.Range(0, items.Count - 1))
            {
                if (items[i + 1] - items[i] == 1)
                    one++;
                else if (items[i + 1] - items[i] == 3)
                    three++;
            }
            return (one * three).ToString();
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
