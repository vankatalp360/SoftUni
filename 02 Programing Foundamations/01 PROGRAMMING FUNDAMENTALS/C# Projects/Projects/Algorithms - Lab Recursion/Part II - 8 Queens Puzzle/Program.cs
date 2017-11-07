using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_II___8_Queens_Puzzle
{
    class Program
    {
        static int size = 8;
        static bool[,] matrix = new bool[size, size];
       // static HashSet<int> recervedRows = new HashSet<int>();
        static HashSet<int> recervedColumns = new HashSet<int>();
        static HashSet<int> recervedLeftDiagonals = new HashSet<int>();
        static HashSet<int> recervedRightDiagonals = new HashSet<int>();
        static int counter = 0;

        static void Main(string[] args)
        {
            GenerateResult(0);
            Console.WriteLine(counter);
        }

        private static void GenerateResult(int row)
        {
            if (row >= size)
            {
                counter++;
                PrintMatrix();
            }
            else
            {
                for (int col = 0; col < size; col++)
                {
                    if (CanPlaceQueen(row, col))
                    {
                        MarkedAllRecervedPositions(row, col);
                        GenerateResult(row + 1);
                        UnmarkedAllRecervedPositions(row, col);
                    }
                }
            }
        }

        private static void UnmarkedAllRecervedPositions(int row, int col)
        {
            //recervedRows.Remove(row);
            recervedColumns.Remove(col);
            recervedLeftDiagonals.Remove(col - row);
            recervedRightDiagonals.Remove(col + row);
            matrix[row, col] = false;
        }

        private static void MarkedAllRecervedPositions(int row, int col)
        {
            //recervedRows.Add(row);
            recervedColumns.Add(col);
            recervedLeftDiagonals.Add(col - row);
            recervedRightDiagonals.Add(col + row);
            matrix[row, col] = true;
        }

        private static bool CanPlaceQueen(int row, int col)
        {
            bool positionRecerved = recervedColumns.Contains(col)
                 || recervedLeftDiagonals.Contains(col - row) || recervedRightDiagonals.Contains(col + row);
                 //|| recervedRows.Contains(row);
            return !positionRecerved;
        }

        private static void PrintMatrix()
        {
            for(int i =0; i< matrix.GetLength(0);i++)
            {
                for(int j = 0; j < matrix.GetLength(1);j++)
                {
                    if (matrix[i,j])
                    {
                        Console.Write("Q");
                    }
                    else
                    {
                        Console.Write("-");
                    }                    
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
