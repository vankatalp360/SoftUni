using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Exercises_Strings_and_Text_Processing
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger[] numbers = Console.ReadLine().Split(' ').Select(BigInteger.Parse).ToArray();
            BigInteger numberBase = numbers[0];
            BigInteger number = numbers[1];
            List<BigInteger> result = new List<BigInteger>();
            while (number > 0)
            {
                BigInteger i = number % numberBase;
                result.Add(i);
                number = number / numberBase;
            }
            result.Reverse();
            Console.WriteLine(string.Join("", result));
        }
    }
}
