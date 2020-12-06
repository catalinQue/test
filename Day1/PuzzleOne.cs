using Common;


namespace Day1
{
    internal class PuzzleOne : IPuzzle
    {
        public string Solve()
        {
            var inputValues = Inputs.GetInputsValues();
            var sumValue = Inputs.GetSumValue();

            for (var i = 0; i < inputValues.Count; i++)
                for (var j = i + 1; j< inputValues.Count; j++) 
                {
                    if (inputValues[i] + inputValues[j] == sumValue)
                        return (inputValues[i] * inputValues[j]).ToString();

                }

            return string.Empty;
        }
    }
}
