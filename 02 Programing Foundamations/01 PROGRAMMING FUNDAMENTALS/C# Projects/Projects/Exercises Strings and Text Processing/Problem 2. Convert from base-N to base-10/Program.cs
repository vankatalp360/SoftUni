using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Convert_from_base_N_to_base_10
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(' ').ToArray();
            int numberBase = int.Parse(numbers[0]);
            int[] number = numbers[1].ToCharArray().Select(x => x.ToString()).Select(int.Parse).ToArray();
            BigInteger result = 0;
            for (int i = number.Length - 1; i >= 0; i--)
            {
                result += number[i] * CalculateMathPow(numberBase, number.Length - 1 - i);
            }
            Console.WriteLine(result);
        }
        private static BigInteger CalculateMathPow(int number, int pow)
        {
            BigInteger result = 1;
            for (int i = 0; i < pow; i++)
            {
                result *= number;
            }
            return result;
        }
    }
}
