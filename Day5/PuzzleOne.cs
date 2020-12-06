using Common;
using System;
using System.Linq;

namespace Day5
{
    public class PuzzleOne : IPuzzle
    {
        public string Solve()
        {
            var inputs = Inputs.GetInputsValues("5");
            var lines = inputs.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            var seats = Seat.Parse(inputs);
            return seats.Max(s => s.Id).ToString();
        }
    }
}
