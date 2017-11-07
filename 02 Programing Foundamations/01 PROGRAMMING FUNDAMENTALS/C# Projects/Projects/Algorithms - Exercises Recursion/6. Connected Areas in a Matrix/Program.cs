using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Connected_Areas_in_a_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            int numberOfColumns = int.Parse(Console.ReadLine());
            string[,] matrix = new string[numberOfRows, numberOfColumns];
            List<Area> areasLog = new List<Area>();
            ReadMatrix(matrix);
            ReadAreas(matrix, areasLog);
            PrintResult(areasLog);
        }

        private static void PrintResult(List<Area> areasLog)
        {
            Console.WriteLine($"Total areas found: {areasLog.Count}");
            if (areasLog.Count != 0)
            {
                int counter = 1;
                foreach (var area in areasLog.OrderByDescending(x => x.Size).ThenBy(x => x.Coordinates[0]).ThenBy(x => x.Coordinates[1]).ToList())
                {
                    Console.WriteLine($"Area #{counter} at ({area.Coordinates[0]}, {area.Coordinates[1]}), size: {area.Size}");
                    counter++;
                }
            }
        }

        private static void ReadAreas(string[,] matrix, List<Area> areasLog)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == "*") continue;
                    
                    int currentArea = FindCurrentAreaSize(matrix, i, j);
                    Area memeber = new Area();
                    memeber.Coordinates = new int[2];
                    memeber.Coordinates[0] = i;
                    memeber.Coordinates[1] = j;
                    memeber.Size = currentArea;
                    areasLog.Add(memeber);
                }
            }
        }

        private static int FindCurrentAreaSize(string[,] matrix, int row, int col)
        {
            if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1) || matrix[row, col] == "*")
            {
                return 0;
            }
            int area = 1;
            matrix[row, col] = "*";

            area += FindCurrentAreaSize(matrix, row, col + 1);
            area += FindCurrentAreaSize(matrix, row, col - 1);
            area += FindCurrentAreaSize(matrix, row + 1, col);
            area += FindCurrentAreaSize(matrix, row -1, col);
            return area;
        }

        private static void ReadMatrix(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string word = Console.ReadLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = word[j].ToString();
                }
            }
        }
    }

    class Area
    {
        public int[] Coordinates { get; set; }
        public int Size { get; set; }
    }
}