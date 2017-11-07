using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___3.English_Name_оf_The_Last_Digit
{
    class Program
    {
        static void Main(string[] args)
        {
            string Number = Console.ReadLine();
            char LastDigit = DefineTheLastDigit(Number);
            Console.WriteLine(LastDigitLetter(LastDigit));
        }
        private static char DefineTheLastDigit(string number)
        {
            char[] c = number.ToCharArray();
            return c[number.Length-1];
        }
        private static string LastDigitLetter(char LastDigit)
        {
            string Letter = null;
            switch (LastDigit)
            {
                case '0':
                    Letter = "zero";
                    break;
                case '1':
                    Letter = "one";
                    break;
                case '2':
                    Letter = "two";
                    break;
                case '3':
                    Letter = "three";
                    break;
                case '4':
                    Letter = "four";
                    break;
                case '5':
                    Letter = "five";
                    break;
                case '6':
                    Letter = "six";
                    break;
                case '7':
                    Letter = "seven";
                    break;
                case '8':
                    Letter = "eight";
                    break;
                case '9':
                    Letter = "nine";
                    break;
                default:
                    break;
            }
            return Letter;
        }
    }
}

