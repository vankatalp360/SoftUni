using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_8.Recursive_Fibonacci
{
    class Program
    {
        private static long[] memo;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            memo = new long[n + 1];
            long result = Recursive_Fibonacci(n);
            Console.WriteLine(result);
        }

        static long Recursive_Fibonacci(int n)
        {
            if (n <= 2)
            {
                return 1;
            }

            if (memo[n] != 0)
            {
                return memo[n];
            }

            memo[n] =
                   Recursive_Fibonacci(n - 1) +
                           Recursive_Fibonacci(n - 2);
            return memo[n];
        }
    }
}
