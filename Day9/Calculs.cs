using System.Collections.Generic;
using System.Linq;

namespace Day9
{
    internal class Calculs
    {
        static int position = 25;

        public static long PartOne(List<long> lines)
        {
            for (int i = position; i < lines.Count; i++)
            {
                var sums = new List<long>();
                for (int j = i - position; j < i - 1; j++)
                {
                    for (int k = 0; k < position; k++)
                    {
                        sums.Add(lines[j] + lines[j + k]);
                    }
                }
                if (!sums.Contains(lines[i]))
                {
                    return lines[i];
                }
            }
            return 0;
        }

        public static long PartTwo(List<long> lines)
        {
            var numberToCheck = PartOne(lines);

            for (int i = 0; i < lines.Count - 1; i++)
            {
                for (int j = 1; j < lines.Count - i; j++)
                {
                    var result = lines.Skip(i).Take(j + 1);
                    long sum = result.Sum();
                    if (sum >= numberToCheck)
                    {
                        if (sum == numberToCheck)
                        {
                            return (result.Max() + result.Min());
                        }
                        break;
                    }
                }
            }
            return 0;
        }

    }
}
