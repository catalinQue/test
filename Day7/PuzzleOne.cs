using Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day7
{
    internal class PuzzleOne : IPuzzle
    {
        public string Solve()
        {
            var inputs = Inputs.GetInputsValues("7");
            var lines = inputs.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

             return GetBagResults(lines).ToString();
        }

        private int GetBagResults(string[] inputValues)
        {
            const string BAGS_TO_FIND = "shiny gold bag";
            const string CONTAIN = "contain";

            int bagResults = 0;
            List<string> bagsChecked = new List<string>();
            string[] bagsToFind = new string[] { BAGS_TO_FIND };

            while (bagsToFind.Length != 0)
            {
                List<string> newBagsToFind = new List<string>();

                for (int i = 0; i < inputValues.Length; i++)
                {
                    string bagName = inputValues[i].Substring(0, inputValues[i].IndexOf(CONTAIN) - 2);
                    string bagsContained = inputValues[i].Substring(inputValues[i].IndexOf(CONTAIN));

                    foreach (string bag in bagsToFind)
                    {
                        if (bagsContained.Contains(bag))
                        {
                            if (!bagsChecked.Contains(bagName))
                            {
                                newBagsToFind.Add(bagName);
                                bagsChecked.Add(bagName);
                                bagResults++;
                            }
                            break;
                        }
                    }
                }
                bagsToFind = newBagsToFind.ToArray();
            }
            return bagResults;
        }
    }
}
