
using System.Linq;

namespace Day3
{
    internal class Tree
    {
        public static int Calcutate(int down, int right, string[] lines)
        {
            var map = lines.Select(line => line.Select(c => c is '.').ToArray()).ToArray();
            var x = 0;
            var nbTrees = 0;
            for (int y = 0; y < map.Length; y += down)
            {
                if (!map[y][x % map[y].Length])
                    nbTrees++;
                x += right;
            }
            return nbTrees;
        }

    }
}

