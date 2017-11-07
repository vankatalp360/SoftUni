using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Master_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int end = int.Parse(Console.ReadLine());
            for (int i = 1; i <= end; i++)
            {
                if (IsSymmetric(i) && IsSumDigitsOfNumberDevidedBySevenAndHasEven(i)) Console.WriteLine(i);
            }
        }

        private static bool IsSumDigitsOfNumberDevidedBySevenAndHasEven(int number)
        {
            char[] words = number.ToString().ToCharArray();
            int sum = 0;
            bool even = false;
            for (int i = 0; i < words.Length; i++)
            {
                sum = sum + int.Parse(words[i].ToString());
                if (even == false && words[i] % 2 == 0) even = true;
            }
            return (sum % 7 == 0 && even);
        }
        private static bool IsSymmetric(int number)
        {
            char[] words = number.ToString().ToCharArray();
            if (words.Length <= 1)
            {
                return true;
            }
            for (int i = 0; i < words.Length / 2; i++)
            {
                if (words[i] != words[words.Length - 1 - i]) return false;
            }
            return true;
        }
    }
}
