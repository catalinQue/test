using Common;
using System;

namespace Day8
{
    internal class PuzzleTwo : IPuzzle
    {
        Program program = new Program();

        public string Solve()
        {
            var inputs = Inputs.GetInputsValues("8");
            var lines = inputs.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            int result = 0;
            int i = 0;

            foreach(var line in lines)
            {
                string[] cpyInput = new string[lines.Length];
                CopyLinesToArray(lines, cpyInput);

                if (line.Substring(0, 3) == "nop")
                {
                    result = GoHabs(lines, cpyInput,"nop", "jmp",i);
                }
                if (line.Substring(0, 3) == "jmp")
                {
                    result = GoHabs(lines, cpyInput, "jmp", "nop", i);

                }
                if (program.isTerminated)
                    return result.ToString();
                i++;
            }

            return string.Empty;
        }

        private int GoHabs(string[] input, string[] copy, string source, string destination, int count)
        {
            copy[count] = copy[count].Replace(source, destination);

            return program.Execute(copy);
        }

        private Array CopyLinesToArray(string[]  source, Array destination)
        {
            Array.Copy(source, destination, source.Length);
            return destination;
        }


    }
}
