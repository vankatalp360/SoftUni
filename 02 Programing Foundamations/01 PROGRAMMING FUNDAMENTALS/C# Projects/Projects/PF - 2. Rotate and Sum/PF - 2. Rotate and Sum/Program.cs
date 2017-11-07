using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___2.Rotate_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
             .Split(' ')
             .Select(int.Parse)
             .ToArray();
            int Rotates = int.Parse(Console.ReadLine());
            int[] Sumarray = new int[array.Length];

            for (int i = 1; i <= Rotates; i++)
            {
                ArrayShiftRight(array);
                SumTwoArrays(Sumarray, array);
            }
            PrintArray(Sumarray);
        }
        private static void ArrayShiftRight(int[] array)
        {
            int temp = array[array.Length - 1];
            for (int i = array.Length - 1; i >= 1; i--)
            {
                array[i] = array[i - 1];
            }
            array[0] = temp;
        }

        private static void SumTwoArrays(int[] firstarray, int[] secondarray)
        {
            for (int i = firstarray.Length - 1; i >= 0; i--)
            {
                int temp = firstarray[i];
                firstarray[i] = temp + secondarray[i];
            }
        }
        private static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
    }
}

