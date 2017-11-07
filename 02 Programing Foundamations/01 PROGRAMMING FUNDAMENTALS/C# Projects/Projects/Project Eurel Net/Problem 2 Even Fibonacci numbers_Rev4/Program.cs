using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());
            Func<BigInteger, BigInteger> fibunachi = n => n == 0 ? 1 :
            Enumerable.Range(1, (int)n).Select(x => (BigInteger)x).Aggregate((acc, x) => acc * x);
            Console.WriteLine(fibunachi(end));
        }
    }
}
