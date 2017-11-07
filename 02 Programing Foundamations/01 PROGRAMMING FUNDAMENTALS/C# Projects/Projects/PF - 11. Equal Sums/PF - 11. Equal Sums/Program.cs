using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___11.Equal_Sums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] Array = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            bool result = false;
            for (int i = 0; i <= Array.Length; i++)
            {
                int LeftSum = CalculateLeftSum(Array, i);
                int RightSum = CalculateRightSum(Array, i);
                if (RightSum == LeftSum)
                {
                    result = true;
                    Console.WriteLine(i);
                }
            }
            if (!result) Console.WriteLine("no");
        }
        private static int CalculateLeftSum(int[] array, int pos)
        {
            int Sum = 0;
            for (int i = pos - 1; i >= 0; i--)
            {
                Sum += array[i];
            }
            return Sum;
        }
        private static int CalculateRightSum(int[] array, int pos)
        {
            int Sum = 0;
            for (int i = pos + 1; i < array.Length; i++)
            {
                Sum += array[i];
            }
            return Sum;
        }
    }
}
