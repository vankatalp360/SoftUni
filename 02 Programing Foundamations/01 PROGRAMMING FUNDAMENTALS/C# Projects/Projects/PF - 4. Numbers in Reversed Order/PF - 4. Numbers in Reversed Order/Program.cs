using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___4.Numbers_in_Reversed_Order
{
    class Program
    {
        static void Main(string[] args)
        {
            string Number = Console.ReadLine();
            string ReversedLetter=ReverseTheLetter(Number);
            Console.WriteLine(RemoveZeros(ReversedLetter));
        }
        private static string ReverseTheLetter(string Letter)
        {
            char[] CharLetter = Letter.ToCharArray();
            string ReversedString = null;
            int a = 0;
            if (CharLetter[0] == '-')
            {
                a = 1;
                ReversedString += CharLetter[0];
            }
            for (int i = Letter.Length - 1; i >= a; i--)
            {
                ReversedString += CharLetter[i];
            }
            return ReversedString;
        }
        private static string RemoveZeros(string Letter)
        {
            string TheNewString = null;
            char[] CharLetter = Letter.ToCharArray();
            int i = 0;
            if (CharLetter[0] == '-')
            {
                TheNewString += CharLetter[0];
                i = 1;
            }
            while (true)
            {
                if (CharLetter[i] == '0'&&i<Letter.Length)
                {
                    i++;
                }
                else break;
            }
            for (int j=i; j<Letter.Length;j++)
            {
                TheNewString += CharLetter[j];
            }
            return TheNewString;
        }
    }
}
