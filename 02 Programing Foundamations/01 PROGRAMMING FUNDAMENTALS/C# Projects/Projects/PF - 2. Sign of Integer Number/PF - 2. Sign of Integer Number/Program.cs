using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___2.Sign_of_Integer_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            PrintSign(N);
        }
        static void PrintSign(int N)
        {
            Console.WriteLine("The number {0} is {1}.",N,DefineTheNumber(N));
        }
        static string DefineTheNumber(int N)
        {
            string Letter;
            if (N < 0) Letter = "negative";
            else if (N == 0) Letter = "zero";
            else Letter = "positive";
            return Letter;
        }
    }
}
