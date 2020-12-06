using System;
using Common;

namespace AdventOfCode
{
    public class DayProvider
    {
        public static IPuzzle GetPuzzle(int day, string part)
         {
            var objectToInstantiate = $"Day{day}.Puzzle{part}, Day{day}";

            var objectType = Type.GetType(objectToInstantiate);

            return Activator.CreateInstance(objectType) as IPuzzle; 
        }

}
}
