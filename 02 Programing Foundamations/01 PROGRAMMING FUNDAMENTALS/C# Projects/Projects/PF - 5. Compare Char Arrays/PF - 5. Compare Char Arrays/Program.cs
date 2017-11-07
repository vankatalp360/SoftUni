using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___5.Compare_Char_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] FirstArray = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            char[] SecondArray = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            bool Compare = CompareTwoCharArrays(FirstArray, SecondArray);

            if (Compare)
            {
                PrintArray(FirstArray);
                PrintArray(SecondArray);
            }
            else
            {
                PrintArray(SecondArray);
                PrintArray(FirstArray);
            }
        }
        private static void PrintArray(char[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
            }
            Console.WriteLine();
        }
        private static bool CompareTwoCharArrays(char[] FirstArray, char[] SecondArray)
        {
            bool Result = true;
            int TheLimit = Math.Min(FirstArray.Length, SecondArray.Length);
            for (int i = 0; i < TheLimit; i++)
            {
                Result = (FirstArray[i] <= SecondArray[i]);
                if (Result == false) break;
            }
            if (Result) Result = (FirstArray.Length <= SecondArray.Length);
            return Result;
        }
    }
}
