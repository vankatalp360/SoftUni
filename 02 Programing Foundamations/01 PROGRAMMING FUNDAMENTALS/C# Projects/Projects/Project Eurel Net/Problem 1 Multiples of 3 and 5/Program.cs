using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1_Multiples_of_3_and_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int target = 999;
            for (int i = 1; i <= target; i++)
            {
                if (i % 3 == 0 || i % 5 == 0) sum += i;
            }
            Console.WriteLine(sum);
            int result3 = SumDivisibleBy(3, target);
            Console.WriteLine(result3);
            int result5 = SumDivisibleBy(5, target);
            Console.WriteLine(result5);
            Console.WriteLine(result3 + result5);
        }
        private static int SumDivisibleBy(int n, int target)
        {
            int p = target / n;
            return n * (p * (p + 1)) / 2;
        }
    }
}
