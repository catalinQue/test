using Common;
using System;

namespace Day5
{
    internal class PuzzleTwo : IPuzzle
    {
        public string Solve()
        {
            var inputs = Inputs.GetInputsValues("5");
            var lines = inputs.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            var takenSeats = Seat.Parse(inputs);
            var plane = new Plane(takenSeats);
            var availableSeats = plane.GetAvailableSeats();

            foreach (var seat in availableSeats)
            {
                if (takenSeats.Contains(seat.Id - 1) && takenSeats.Contains(seat.Id + 1))
                    return seat.Id.ToString();
            }

            return string.Empty;
        }
    }
}
