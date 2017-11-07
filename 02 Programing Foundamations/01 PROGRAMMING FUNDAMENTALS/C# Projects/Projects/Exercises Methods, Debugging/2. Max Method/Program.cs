using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Max_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 3;
            int maxValue = int.MinValue;
            maxValue = FindMaxValue(n, maxValue);
            PrintMaxNumber(maxValue);
        }

        private static int FindMaxValue(int n, int maxValue)
        {
            for (int i = 1; i <= n; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                if (maxValue < currentNumber) maxValue = currentNumber;
            }

            return maxValue;
        }

        private static void PrintMaxNumber(int maxValue)
        {
            Console.WriteLine(maxValue);
        }
    }
}
