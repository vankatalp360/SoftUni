using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Numbers_in_Reversed_Order
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            bool possitive = false;
            if (number >= 0) possitive = true;
            char[] numberLetter = number.ToString().ToCharArray();
            char[] reversedNumber = ReverseTheNumber(numberLetter, possitive);
            PrintTheReversedNumber(reversedNumber);
        }

        private static void PrintTheReversedNumber(char[] reversedNumber)
        {
            Console.WriteLine(string.Join("", reversedNumber));
        }

        private static char[] ReverseTheNumber(char[] number, bool possitive)
        {
            int length = number.Length;
            char[] reversedNumber = new char[length];
            int start;

            if (possitive)
            {
                start = 0;
            }
            else
            {
                start = 1;
                length = length + 1;
                reversedNumber[0] = number[0];
            }
            for (int i = start; i < number.Length; i++)
            {
                reversedNumber[i] = number[length - 1 - i];
            }
            return reversedNumber;
        }
    }
}
