using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Sum__Min__Max__Average
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long totalSum = 0;
            int minNumber = int.MaxValue;
            int maxNumber = int.MinValue;
            double average = 0;

            for (int i = 1; i <= n; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                totalSum += currentNumber;
                if (minNumber > currentNumber) minNumber = currentNumber;
                if (maxNumber < currentNumber) maxNumber = currentNumber;
            }
            average = (double)totalSum / n;
            Console.WriteLine($"Sum = {totalSum}");
            Console.WriteLine($"Min = {minNumber}");
            Console.WriteLine($"Max = {maxNumber}");
            Console.WriteLine($"Average = {average}");
        }
    }
}
