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
            for (int i = 1; i <= number; i++)
            {
                result = result * i;
            }
            int couter = 0;
            string words = result.ToString();
            for (int i= words.Length-1; i >=0;i--)
            {
                if (words[i] == '0') couter++; else break;
            }
            Console.WriteLine(couter);
        }
    }
}
