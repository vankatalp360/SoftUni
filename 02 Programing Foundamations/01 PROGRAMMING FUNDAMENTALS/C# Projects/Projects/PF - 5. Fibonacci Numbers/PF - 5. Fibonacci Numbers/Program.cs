using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___5.Fibonacci_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int Fib=0;
            if (N == 0 ) Fib = 1;
            else if (N >= 1) Fib = CalculateFibResult(N);
            Console.WriteLine(Fib);
        }
        private static int CalculateFibResult(int Number)
        {
            int LastFib = 0;
            int CurrentFib = 1;
            for (int i =1;i<=Number;i++)
            {
                int temp = CurrentFib;
                CurrentFib += LastFib;
                LastFib = temp;
            }
            return CurrentFib;
        }
    }
}
