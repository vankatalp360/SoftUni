using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4___Cubic_s_Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            string Message = Console.ReadLine();
            while (Message != "Over!")
            {
                int N = int.Parse(Console.ReadLine());
                char[] Letters = Message.ToCharArray();
                List<int> Digits = new List<int>();
                DefineTheDigitsBeforeMassage(Letters, Digits);
                Message = Message.Substring(Digits.Count, Message.Length - Digits.Count);
                Letters = Message.ToCharArray();
                List<char> AlphabeticLetter = DefineMessage(Letters);
                if (AlphabeticLetter.Count == N)
                {
                    Message = Message.Substring(AlphabeticLetter.Count, Message.Length - AlphabeticLetter.Count);
                    Letters = Message.ToCharArray();
                    if (!DoesContainAlphabetLetters(Letters) || !Letters.Any())
                    {
                        DefineTheDigitsAfterMassage(Letters, Digits);
                        string verificationCode = null;
                        foreach (int i in Digits)
                        {
                            if (i < 0 || i >= AlphabeticLetter.Count) verificationCode += ' ';
                            else verificationCode += AlphabeticLetter[i];
                        }
                        Console.WriteLine($"{string.Join("", AlphabeticLetter)} == {verificationCode}");
                    }
                }
                Message = Console.ReadLine();
            }
        }
        private static void DefineTheDigitsBeforeMassage(char[] Letters, List<int> Digits)
        {
            char[] Exceptions = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            foreach (char i in Letters)
            {
                if (Exceptions.Contains(i)) Digits.Add(int.Parse(i.ToString()));
                else break;
            }
        }
        private static List<char> DefineMessage(char[] Letters)
        {
            List<char> AlphabeticLetter = new List<char>();
            foreach (char i in Letters)
            {
                if (i >= 65 && i <= 122 && (i <= 90 || i >= 97)) AlphabeticLetter.Add(i);
                else break;
            }
            return AlphabeticLetter;
        }
        private static bool DoesContainAlphabetLetters(char[] Letters)
        {
            bool result = true;
            foreach (char i in Letters)
            {
                if (i >= 65 && i <= 122 && (i <= 90 || i >= 97)) { result = true; break; } else result = false;
            }
            return result;
        }
        private static void DefineTheDigitsAfterMassage(char[] Letters, List<int> Digits)
        {
            char[] Exceptions = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            foreach (char i in Letters)
            {
                if (Exceptions.Contains(i)) Digits.Add(int.Parse(i.ToString()));
            }
        }
    }
}
