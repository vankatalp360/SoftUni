using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___6.Prime_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            long Numer = long.Parse(Console.ReadLine());
            bool Result = false;
            if (Numer >= 2) Result = IsNumberPrime(Numer);
            Console.WriteLine(Result);
        }
        private static bool IsNumberPrime(long number)
        {
            bool Result = true;
            for (long i = 2; i <= Math.Sqrt(number) ; i++)
            {
                if (number % i == 0)
                {
                    Result = false;
                    break;
                }
            }
            return Result;
        }
    }
}
