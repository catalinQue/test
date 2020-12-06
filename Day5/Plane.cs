using System.Collections.Generic;

namespace Day5
{
    public class Plane
    {
        private Seat[,] availability = new Seat[128, 8];

        public Plane(Seat[] takenSeats)
        {
            foreach (var seat in takenSeats)
                availability[seat.Row, seat.Column] = seat;
        }

        internal Seat[] GetAvailableSeats()
        {
            var result = new List<Seat>();

            for (int row = 1; row < 127; row++)
                for (int column = 0; column < 7; column++)
                    if (availability[row, column] == null)
                        result.Add(new Seat(row, column));

            return result.ToArray();
        }
    }
}
