using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___15.Fast_Prime_Checker___Refactor
{
    class Program
    {
        static void Main(string[] args)
        {
            int TheNumber = int.Parse(Console.ReadLine());
            for (int NumberValue = 2; NumberValue <= TheNumber; NumberValue++)
            {
                bool Result = true;
                for (int j = 2; j <= Math.Sqrt(NumberValue); j++)
                {
                    if (NumberValue % j == 0)
                    {
                        Result = false;
                        break;
                    }
                }
                Console.WriteLine($"{NumberValue} -> {Result}");
            }
        }
    }
}
