using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Generating_Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] set = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int size = int.Parse(Console.ReadLine());
            int[] vector = new int[size];
            GenerateCombinations(vector, set, 0, 0);
        }

        private static void GenerateCombinations(int[] vector, int[] set, int index, int border)
        {
            if (index >= vector.Length)
            {
                PrintResult(vector);
                return;
            }
            else
            {
                for (int i = border; i < set.Length; i++)
                {
                    vector[index] = set[i];
                    GenerateCombinations(vector, set, index + 1, i + 1);
                }
            }
        }

        private static void PrintResult(int[] vector)
        {
            Console.WriteLine(string.Join(" ",vector));
        }
    }
}
