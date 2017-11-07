using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part_III___Find_All_Paths_in_a_Labyrinth
{
    class Program
    {
        static List<char> path = new List<char>();
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            char[,] matrix = new char[rows, cols];
            ReadMatrix(rows, cols, matrix);
            // PrintMatrix(matrix);
            GeneratePathToExit(matrix, 0, 0,'S');
        }

        private static void GeneratePathToExit(char[,] matrix, int row, int col, char direction)
        {
            if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
            {
                return;
            }
            path.Add(direction);
            if (matrix[row, col] == 'e')
            {
                path.Add('E');
                PrintResult();
            }
            else if (matrix[row, col] != '.' && matrix[row, col] != '*')
            {
                matrix[row, col] = '.';
                GeneratePathToExit(matrix,row, col + 1,'R'); // Right
                GeneratePathToExit(matrix,row + 1, col, 'D'); // Down
                GeneratePathToExit(matrix,row, col - 1, 'L'); // Left
                GeneratePathToExit(matrix,row - 1, col, 'U'); // Up
                matrix[row, col] = '-';
            }
            path.RemoveAt(path.Count - 1);
        }

        private static void PrintResult()
        {
            Console.WriteLine("Path found!");
            Console.WriteLine(string.Join("", path));
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static void ReadMatrix(int rows, int cols, char[,] matrix)
        {
            for (int i = 0; i < rows; i++)
            {
                char[] elements = Console.ReadLine().ToCharArray();
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = elements[j];
                }
            }
        }
    }
}
