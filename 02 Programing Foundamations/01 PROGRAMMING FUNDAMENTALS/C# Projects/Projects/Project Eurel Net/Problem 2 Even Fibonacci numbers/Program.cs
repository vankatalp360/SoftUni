using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2_Even_Fibonacci_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            long sumEven = 0;
            long maxFibNumber = 4000000;
            int fib0 = 1;
            int fib1 = 1;
            int fib2 = fib0 + fib1;
            while (fib2 <= maxFibNumber)
            {
                if (fib2 % 2 == 0) sumEven += fib2;
                fib0 = fib1;
                fib1 = fib2;
                fib2 = fib0 + fib1;
            }
            Console.WriteLine(sumEven);
        }

    }
}
