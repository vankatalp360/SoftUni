using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Fibonacci_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long current = DefineFib(n);
            Console.WriteLine(current);
        }

        private static long DefineFib(int n)
        {
            long current = 1;
            if (n > 2)
            {
                long first = 1;
                long second = 2;
                for (int i = 2; i < n; i++)
                {
                    current = first + second;
                    first = second;
                    second = current;
                }
            }

            return current;
        }
    }
}
