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
            long fib = 0;
            int counter = 0;
            while (Recuursion1(fib) <= maxFibNumber)
            {
                counter++;
                if (counter == 3)
                {
                    counter = 0;
                    sumEven += Recuursion1(fib);
                }
                fib++;
            }
            Console.WriteLine(sumEven);
        }

        private static long Recuursion1(long fib)
        {
            if (fib <= 0) return 0;
            if (fib == 0) return 1;
            if (fib == 1) return 1;
            if (fib == 2) return 2;
            if (fib == 3) return 3;
            if (fib == 4) return 5;
            if (fib == 5) return 8;
            if (fib == 6) return 13;

            fib = 4 * Recuursion1(fib - 3) + Recuursion1(fib - 6);
            return fib;
        }
        private static long Recuursion2(long fib)
        {
            if (fib <= 0) return 0;
            if (fib == 0) return 1;
            if (fib == 1) return 1;
            if (fib == 2) return 2;
            if (fib == 3) return 3;

            fib = 2 * Recuursion2(fib - 2) + Recuursion2(fib - 3);
            return fib;
        }
    }
}
