using System.Collections.Generic;
using Common;


namespace Day1
{
    internal class PuzzleTwo : IPuzzle
    {
        public string Solve()
        {

            var inputValues = Inputs.GetInputsValues();
            var sumValue = Inputs.GetSumValue();

            for (int i = 0; i < inputValues.Count; i++)
                 for (int j = i + 1; j < inputValues.Count; j++)
                     for (int k = j + 1; k < inputValues.Count; k++)
                     {
                         if (inputValues[i] + inputValues[j] + inputValues[k] == sumValue)
                             return (inputValues[i] * inputValues[j] * inputValues[k]).ToString();
                     }
            return string.Empty;
        }
    }
}
