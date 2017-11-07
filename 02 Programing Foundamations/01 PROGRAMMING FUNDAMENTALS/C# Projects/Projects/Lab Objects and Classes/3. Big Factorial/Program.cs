using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Big_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());
            if (end >= 0)
            {
                BigInteger result = 1;
                for (int i = 2; i <= end; i++)
                {
                    result = result * i;
                }
                Console.WriteLine(result);
            }
        }
    }
}
