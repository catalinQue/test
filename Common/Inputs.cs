using System;
using System.IO;

namespace Common
{
    public class Inputs
    {
        public static string GetInputsValues(string day)
        {
            var inputs = string.Empty;

            using (StreamReader stream = File.OpenText("Inputs" + day + ".txt"))
            {
                string line = string.Empty;
                while ((line = stream.ReadLine()) != null)
                {
                    inputs += line + Environment.NewLine;
                }
            }
            return inputs;
        }
    }
}