using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day7
{
    internal class PuzzleTwo : IPuzzle
    {
        const string BAG_COLOR_SHINY_GOLD = "shiny gold";

        public string Solve()
        {
            var inputs = File.ReadAllLines("Inputs7.txt");

            return CountBags(GetBags(inputs).Find(x => x.Color == BAG_COLOR_SHINY_GOLD), 1).ToString();
        }

        private List<Bag> GetBags(string[] inputValues)
        {
            var bags = new List<Bag>();
            var bagsContainingGold = new Dictionary<Bag, int>();

            foreach (string line in inputValues)
            {
                string[] tempLine = GetLines(line);
                if (!bags.Contains(bags.Find(x => x.Color == tempLine[0])))
                    bags.Add(new Bag(tempLine[0], tempLine));
            }

            foreach (Bag bag in bags)
            {
                bag.AddContents(bags);

                if (!bagsContainingGold.ContainsKey(bag))
                    CheckBagsForSG(bag, bagsContainingGold);
            }

            return bags;
        }

        private string[] GetLines(string line)
        {
            return line.Split(new string[] { " contain ", ", ", ".", " bags", " bag" }, StringSplitOptions.RemoveEmptyEntries);
        }

        private int CountBags(Bag bagToCheck, int numberOfbags)
        {
            int bagsInside = 0;
            if (bagToCheck.Contents.Count == 0) return 0;
            foreach (KeyValuePair<Bag, int> kvp in bagToCheck.Contents)
                bagsInside += CountBags(kvp.Key, kvp.Value * numberOfbags) + kvp.Value * numberOfbags;
            return bagsInside;
        }

        private bool CheckBagsForSG(Bag bag, Dictionary<Bag, int> bagsContainingGold)
        {
            bool hasSG = false;
            if (bag.Color == BAG_COLOR_SHINY_GOLD) return true;
            if (bag.Contents.Count == 0) return false;

            foreach (KeyValuePair<Bag, int> kvp in bag.Contents)
            {
                if (CheckBagsForSG(kvp.Key, bagsContainingGold))
                {
                    if (!bagsContainingGold.ContainsKey(bag))
                        bagsContainingGold.Add(bag, 0);
                    hasSG = true;
                }
            }
            return hasSG;
        }      
    }  
}
