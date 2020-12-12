using System.Collections.Generic;
using System.Linq;

namespace Day11
{
    internal class SeatHelper
    {
        public static Seat[,] ParseSeats(string[] items)
        {
            Seat[,] matrix = new Seat[items.Length, items[0].Length];
            for (int x = 0; x < items.Length; x++)
            {
                for (int y = 0; y < items[x].Length; y++)
                {
                    matrix[x, y] = new Seat
                    {
                        IsFloor = items[x][y] == '.',
                        IsOccupied = items[x][y] == '#'
                    };
                }
            }

            return matrix;
        }

        public static int CountSeats(Seat[,] seats)
        {
            return CountSeats(seats, false);
        }

        public static int CountSeats(Seat[,] matrix, bool partOne)
        {
            int maxConter = 100000;
            int counter = 0;
            do
            {
                bool applyRulesIteration = ApplyRulesIteration(matrix, partOne);
                if (applyRulesIteration)
                {
                    counter++;
                }
                else
                {
                    break;
                }
            } while (counter < maxConter);

            return CountOccupiedSeats(matrix);
        }

        private static bool ApplyRulesIteration(Seat[,] matrix, bool partOne)
        {
            bool changeInIteration = false;
            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    if (matrix[x, y].IsFloor)
                    {
                        continue;
                    }

                    List<Seat> adjacentSeats = GetAdjacentSeats(matrix, x, y, partOne);
                    if (matrix[x, y].IsOccupied && adjacentSeats.Count(seat => !seat.IsFloor && seat.IsOccupied) >= (partOne ? 4 : 5))
                    {
                        matrix[x, y].IsOccupiedChangeState = false;
                        changeInIteration = true;
                    }
                    else if (!matrix[x, y].IsOccupied && !adjacentSeats.Any(seat => seat.IsOccupied))
                    {
                        matrix[x, y].IsOccupiedChangeState = true;
                        changeInIteration = true;
                    }
                }
            }

            foreach (Seat seat in matrix)
            {
                if (seat.IsOccupiedChangeState.HasValue)
                {
                    seat.IsOccupied = seat.IsOccupiedChangeState.Value;
                }

            }

            return changeInIteration;
        }

 
        private static List<Seat> AddSeatLeft(List<Seat> seats, Seat[,] matrix, int x, int y, bool partOne)
        {
            for (int i = x - 1; i >= 0; i--)
            {
                if (partOne)
                {
                    seats.Add(matrix[i, y]);
                    break;
                }
                if (matrix[i, y].IsFloor) continue;
                seats.Add(matrix[i, y]);
                break;
            }

            return seats;
        }

        private static List<Seat> AddSeatRight(List<Seat> seats, Seat[,] matrix, int x, int y, bool partOne)
        {
            for (int i = x + 1; i < matrix.GetLength(0); i++)
            {
                if (partOne)
                {
                    seats.Add(matrix[i, y]);
                    break;
                }
                if (matrix[i, y].IsFloor) continue;
                seats.Add(matrix[i, y]);
                break;
            }

            return seats;
        }

        private static List<Seat> AddSeatUp(List<Seat> seats, Seat[,] matrix, int x, int y, bool partOne)
        {
            for (int i = y - 1; i >= 0; i--)
            {
                if (partOne)
                {
                    seats.Add(matrix[x, i]);
                    break;
                }
                if (matrix[x, i].IsFloor) continue;
                seats.Add(matrix[x, i]);
                break;
            }

            return seats;
        }

        private static List<Seat> AddSeatDown(List<Seat> seats, Seat[,] matrix, int x, int y, bool partOne)
        {
            for (int i = y + 1; i < matrix.GetLength(1); i++)
            {
                if (partOne)
                {
                    seats.Add(matrix[x, i]);
                    break;
                }
                if (matrix[x, i].IsFloor) continue;
                seats.Add(matrix[x, i]);
                break;
            }

            return seats;
        }

        private static List<Seat> AddSeatDiagLeftUp(List<Seat> seats, Seat[,] matrix, int x, int y, bool partOne)
        {
            for (int i = x - 1, y2 = y - 1; i >= 0 && y2 >= 0; i--, y2--)
            {
                if (partOne)
                {
                    seats.Add(matrix[i, y2]);
                    break;
                }
                if (matrix[i, y2].IsFloor) continue;
                seats.Add(matrix[i, y2]);
                break;
            }

            return seats;
        }

        private static List<Seat> AddSeatDiagLeftDown(List<Seat> seats, Seat[,] matrix, int x, int y, bool partOne)
        {
            for (int i = x - 1, y2 = y + 1; i >= 0 && y2 < matrix.GetLength(1); i--, y2++)
            {
                if (partOne)
                {
                    seats.Add(matrix[i, y2]);
                    break;
                }
                if (matrix[i, y2].IsFloor) continue;
                seats.Add(matrix[i, y2]);
                break;
            }

            return seats;
        }

        private static List<Seat> AddSeatDiagRightUp(List<Seat> seats, Seat[,] matrix, int x, int y, bool partOne)
        {
            for (int i = x + 1, y2 = y - 1; i < matrix.GetLength(0) && y2 >= 0; i++, y2--)
            {
                if (partOne)
                {
                    seats.Add(matrix[i, y2]);
                    break;
                }
                if (matrix[i, y2].IsFloor) continue;
                seats.Add(matrix[i, y2]);
                break;
            }

            return seats;
        }

        private static List<Seat> AddSeatDiagRightDown(List<Seat> seats, Seat[,] matrix, int x, int y, bool partOne)
        {
            for (int i = x + 1, y2 = y + 1; i < matrix.GetLength(0) && y2 < matrix.GetLength(1); i++, y2++)
            {
                if (partOne)
                {
                    seats.Add(matrix[i, y2]);
                    break;
                }
                if (matrix[i, y2].IsFloor) continue;
                seats.Add(matrix[i, y2]);
                break;
            }

            return seats;
        }

        private static List<Seat> GetAdjacentSeats(Seat[,] matrix, int x, int y, bool partOne)
        {
            List<Seat> seats = new List<Seat>();
            // left
            seats = AddSeatLeft(seats, matrix, x, y, partOne);

            // right
            seats = AddSeatRight(seats, matrix, x, y, partOne);

            // up
            seats = AddSeatUp(seats, matrix, x, y, partOne);

            // down
            seats = AddSeatDown(seats, matrix, x, y, partOne);

            // diagonal left up
            seats = AddSeatDiagLeftUp(seats, matrix, x, y, partOne);

            // diagonal left down
            seats = AddSeatDiagLeftDown(seats, matrix, x, y, partOne);

            // diagonal right up
            seats = AddSeatDiagRightUp(seats, matrix, x, y, partOne);

            // diagonal right down
            seats = AddSeatDiagRightDown(seats, matrix, x, y, partOne);

            return seats;
        }

        private static int CountOccupiedSeats(Seat[,] matrix)
        {
            int count = 0;
            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                {
                    if (matrix[x, y].IsOccupied && !matrix[x, y].IsFloor)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
