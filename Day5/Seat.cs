using System;
using System.Linq;
namespace Day5
{
    public class Seat
    {

        public Seat(string position)
        {
            position = position.Replace("F", "0").Replace("B", "1").Replace("R", "1").Replace("L", "0");
            Row = Convert.ToInt32(position.Substring(0, 7), 2);
            Column = Convert.ToInt32(position.Substring(7), 2);
            Id = Row * 8 + Column;
        }

        public Seat(int row, int column)
        {
            Row = row;
            Column = column;
            Id = Row * 8 + Column;
        }

        public int Id { get; }
        public int Row { get; }
        public int Column { get; }


        public static Seat ParseSingle(string input)
        {
            return new Seat(input);
        }

        public static Seat[] Parse(string inputs)
        {
            string[] values = inputs.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            return values.Select(s => ParseSingle(s)).ToArray();
        }
    }
}
