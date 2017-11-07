using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Rounding_Numbers_Away_from_Zero
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> Numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToList();
            foreach (double number in Numbers)
            {
                Console.WriteLine($"{number} => {Math.Round(number,0,MidpointRounding.AwayFromZero)}");
            }
        }
    }
}
