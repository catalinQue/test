
namespace Day3
{
    internal class Map
    {
        private const char TREE = '#';
        private readonly string[] template;
        private readonly int maxX;
        private readonly int maxY;
        private int x = 0;
        private int y = 0;

        public Map(string[] template)
        {
            this.template = template;
            maxX = template[0].Length;
            maxY = template.Length;
        }

        public void Move(int right, int down)
        {
            x += right;
            if (x >= maxX) x -= maxX;
            y += down;
        }

        public bool Arrived
        {
            get { return y >= maxY; }
        }

        public bool IsTree
        {
            get { return template[y][x] == TREE; }
        }

        public int CountForSlope(int right, int down)
        {
            var count = 0;

            while (!Arrived)
            {
                Move(right, down);
                if (Arrived) break;
                if (IsTree) count++;
            }

            Reset();
            return count;
        }

        public void Reset()
        {
            x = 0; y = 0;
        }
    }

}

