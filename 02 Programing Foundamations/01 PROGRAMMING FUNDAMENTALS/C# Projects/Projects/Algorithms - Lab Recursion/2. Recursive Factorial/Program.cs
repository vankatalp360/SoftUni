using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Recursive_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int topNumber = int.Parse(Console.ReadLine());
            int result = Factorial(topNumber);
            Console.WriteLine(result);
        }

        private static int Factorial(int topNumber)
        {
            if (topNumber == 0 || topNumber == 1)
                return 1;
            int result = Factorial(topNumber - 1) * topNumber;
            return result;
        }
    }
}
