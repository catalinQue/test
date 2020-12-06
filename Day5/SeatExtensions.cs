using System.Linq;

namespace Day5
{
    public static class SeatExtensions
    {
        public static bool Contains(this Seat[] source, int id)
        {
            return source.Count(s => s.Id == id) > 0;
        }
    }
}
