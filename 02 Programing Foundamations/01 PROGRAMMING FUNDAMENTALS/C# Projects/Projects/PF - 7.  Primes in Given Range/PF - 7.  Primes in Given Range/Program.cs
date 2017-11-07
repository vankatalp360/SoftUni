using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___7.Primes_in_Given_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            int FirstNumber = int.Parse(Console.ReadLine());
            int SecondNumber = int.Parse(Console.ReadLine());
            string Letter = null;
            for (int i = FirstNumber; i <= SecondNumber; i++)
            {
                bool Result = false;
                if (i >= 2) Result = IsNumberPrime(i);
                if (Result)
                {
                    if (Letter != null) Letter += ", " + i;
                    else Letter += i;
                }
            }
            Console.WriteLine(Letter);
        }
        private static bool IsNumberPrime(long number)
        {
            bool Result = true;
            for (long i = 2; i <= Math.Sqrt(number); i++)
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
