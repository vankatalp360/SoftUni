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
            
            long maxFibNumber = 4000000;
            int fib0 = 0;
            int fib1 = 2;
            int fib2 = 4*fib1 + fib0;
            long sumEven = fib0+ fib1;
            while (fib2 <= maxFibNumber)
            {
                sumEven += fib2;
                fib0 = fib1;
                fib1 = fib2;
                fib2 = 4 * fib1 + fib0;
            }
            Console.WriteLine(sumEven);
        }
    }
}
