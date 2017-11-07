using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Number_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            long interger;
            double floatingPoint;
            string input = Console.ReadLine();
            try
            {
                interger = long.Parse(input);
                Console.WriteLine("integer");
            }
            catch
            {
                try
                {
                    floatingPoint = double.Parse(input);
                    Console.WriteLine("floating-point");
                }
                catch
                {
                    Console.WriteLine("No integer , no floating-point!");
                }
            }
        }
    }
}
