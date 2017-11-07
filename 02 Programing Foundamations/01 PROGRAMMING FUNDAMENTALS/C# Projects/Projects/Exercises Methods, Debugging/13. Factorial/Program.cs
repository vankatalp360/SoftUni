using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            BigInteger result = 1;
            for (int i =1; i<=number;i++)
            {
                result =result* i;
            }
            Console.WriteLine(result);
        }
    }
}
