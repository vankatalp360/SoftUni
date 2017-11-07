using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___12.Master_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            for (int i = 1; i <= N; i++)
            {
                bool Result = false;
                string Letter = i.ToString();
                char[] Chars = Letter.ToCharArray();
                int LetterLeight = Letter.Length;
                if (IsSumDigitsOfNumberDevidedBySevenAndTwo(i))
                {
                    if (IsNumberSymmetric(LetterLeight, Chars))
                    {
                        Result = true;
                    }
                }
                if (Result)
                {
                    Console.WriteLine(i);
                }
            }
        }
        private static bool IsSumDigitsOfNumberDevidedBySevenAndTwo(int Number)
        {
            bool ResultSumDevidedBySevenAndTwo = false;
            bool ResultDigitDevidedByTwo = false;
            int SumOfDigits = 0;
            while (Number != 0)
            {
                int LastDigit = Number % 10;
                if (LastDigit % 2 == 0 && ResultDigitDevidedByTwo != true) ResultDigitDevidedByTwo = true;
                SumOfDigits = SumOfDigits + LastDigit;
                Number = (Number - LastDigit) / 10;
            }
            if (SumOfDigits % 7 == 0 && ResultDigitDevidedByTwo) ResultSumDevidedBySevenAndTwo = true;
            return ResultSumDevidedBySevenAndTwo;
        }
        private static bool IsNumberSymmetric(int LetterLeight, char[] Chars)
        {
            bool Result = false;
            for (int i = 0; i < LetterLeight / 2; i++)
            {
                if (Chars[i] == Chars[LetterLeight - 1 - i]) Result = true;
                else
                {
                    Result = false;
                    break;
                }
            }
            return Result;
        }
    }
}
