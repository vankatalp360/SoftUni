using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_for_Beginners___24_April_2016
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] elements = CreateMatrix();
            int[] markedElement = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int sumAroundElements = SumAroundElements(elements, markedElement[0], markedElement[1]);
            elements = ModifyAroundElements(elements, markedElement[0], markedElement[1]);
            elements[markedElement[0], markedElement[1]]*=sumAroundElements;
            PrintResult(elements);
        }

        private static void PrintResult(int[,] elements)
        {
            for(int i = 0; i < elements.GetLength(0);i++)
            {
                for(int j = 0; j <elements.GetLength(1);j++)
                {
                    Console.Write("{0} ", elements[i,j]);
                }
                Console.WriteLine();
            }
        }

        private static int[,] ModifyAroundElements(int[,] elements, int row, int col)
        {
            int markedElement = elements[row, col];
            for (int i = -1; i <= 1; i++)
            {
                if (row + i >= 0 && row + i < elements.GetLength(0))
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        if (col + j >= 0 && col + j < elements.GetLength(1))
                        {
                            if (i == 0 && j == 0)
                            {
                                continue;
                            }
                            elements[row + i, col + j] = elements[row + i, col + j] * markedElement;
                        }
                    }
                }
            }
            return elements;
        }

        private static int SumAroundElements(int[,] elements, int row, int col)
        {
            int sum = 0;
            for(int i = -1; i<=1; i++)
            {
                if (row + i >= 0 && row + i < elements.GetLength(0))
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        if (col + j >= 0 && col + j < elements.GetLength(1))
                        {
                            if (i==0&&j==0)
                            {
                                continue;
                            }
                            sum += elements[row + i, col + j];
                        }                            
                    }
                }                   
            }
            return sum;
        }

        private static int[,] CreateMatrix()
        {
            int[] matrixSize = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[,] elements = new int[matrixSize[0], matrixSize[1]];
            for (int i = 0; i < matrixSize[0]; i++)
            {
                int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                for (int j = 0; j < matrixSize[1]; j++)
                {
                    elements[i, j] = input[j];
                }
            }

            return elements;
        }
    }
}
