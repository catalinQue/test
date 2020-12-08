using System.Collections.Generic;

namespace Day7
{
    internal class Bag
    {
        public string Color;
        public string[] Content;
        public Dictionary<Bag, int> Contents = new Dictionary<Bag, int>();

        public Bag(string color, string[] content)
        {
            Color = color;
            Content = content;
        }

        public void AddContents(List<Bag> bags)
        {
            for (int i = 1; i < Content.Length; i++)
            {
                if (!Content[i].Contains("no other"))
                {
                    Contents.Add(bags.Find(x => x.Color == Content[i].Substring(2, Content[i].Length - 2)), int.Parse(Content[i].Substring(0, 1)));
                }
            }
        }
    }
}
