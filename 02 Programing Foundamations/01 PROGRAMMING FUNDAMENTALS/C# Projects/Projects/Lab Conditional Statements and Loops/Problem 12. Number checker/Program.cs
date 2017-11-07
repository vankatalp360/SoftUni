using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_12.Number_checker
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            try
            {
                int number = int.Parse(input);
                Console.WriteLine("It is a number.");
            }
            catch
            {
                Console.WriteLine("Invalid input!");
            }
        }
    }
}
