using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Prime_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            long number = long.Parse(Console.ReadLine());
            if (number >= 0)
            {
                bool result = IsPrime(number);
                Console.WriteLine(result);
            }
        }

        private static bool IsPrime(long number)
        {
            bool result = false;
            if (number >= 2)
            {
                result = true;
                for (int i = 2; i <= Math.Sqrt(number); i++)
                {
                    if (number % i == 0)
                    {
                        result = false;
                        break;
                    }
                }
            }

            return result;
        }
    }
}
