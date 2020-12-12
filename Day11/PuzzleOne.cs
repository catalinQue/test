using Common;
using System.IO;

namespace Day11
{
    internal class PuzzleOne : IPuzzle
    {
        public string Solve()
        {
            string[] lines = File.ReadAllLines("Inputs11.txt");

            Seat[,] seats = SeatHelper.ParseSeats(lines);
            return SeatHelper.CountSeats(seats, true).ToString();
        }

       
    }
}
