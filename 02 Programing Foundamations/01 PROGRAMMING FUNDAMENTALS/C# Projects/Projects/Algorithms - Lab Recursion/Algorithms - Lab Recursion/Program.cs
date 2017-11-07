using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms___Lab_Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int sumAllNumbers = SumArrayNumbers(numbers, 0);
            Console.WriteLine(sumAllNumbers);
        }

        private static int SumArrayNumbers(int[] numbers, int index)
        {
            if (index >= numbers.Length)
                return 0;
            if (index <0 )
            {
                index++;
                return 0;
            }
            int sum = numbers[index];
            sum += SumArrayNumbers(numbers, index + 1);
            return sum;
        }
    }
}
