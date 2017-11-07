using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Big_Factorial_Rev2
{
    class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());
            Func<BigInteger, BigInteger> factorial = 
                n => n == 0 ? new BigInteger(1) :
                 Enumerable.Range( 1, (int)n).Select(p => (BigInteger)p).Aggregate((acc, x) => acc * x);
            Console.WriteLine(factorial(end));
        }
    }
}
