using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___3.Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();
            int[] FirstArray = new int[array.Length / 2];
            int[] SecondArray = new int[array.Length / 2];
            CrateArrays(array, FirstArray, SecondArray);
            int[] Sumarray = new int[array.Length / 2];
            SumTwoArrays(Sumarray, FirstArray);
            SumTwoArrays(Sumarray, SecondArray);
            PrintArray(Sumarray);
        }
        private static void CrateArrays(int[] firstarray, int[] secondarray, int[] thirdarray)
        {
            for (int i = 0; i <= firstarray.Length - 1; i++)
            {
                int temp = firstarray[i];
                if (i <= firstarray.Length / 4 - 1) secondarray[firstarray.Length / 4 - 1 - i] = temp;
                else if (i >= 3 * firstarray.Length / 4) secondarray[firstarray.Length + firstarray.Length / 4 - 1 - i] = temp;
                else thirdarray[i - firstarray.Length / 4] = temp;
            }
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
