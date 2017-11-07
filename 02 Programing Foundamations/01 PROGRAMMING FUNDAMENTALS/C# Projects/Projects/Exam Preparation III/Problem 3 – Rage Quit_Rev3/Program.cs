using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3___Rage_Quit_Rev3
{
    class Program
    {
        static void Main(string[] args)
        {
            string InputLetter = Console.ReadLine().ToUpper();
            char[] Digits = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            string[] Words = InputLetter.Split(Digits, StringSplitOptions.RemoveEmptyEntries).ToArray();
            int[] Numbers = InputLetter.Split(Words, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse). ToArray();
            List<char> UniqueSymbols = new List<char>();
            for (int i = 0; i < Words.Length; i++)
            {
                if (Numbers[i] != 0)
                {
                    char[] AlphabeticUnique = Words[i].ToCharArray();
                    foreach (char j in AlphabeticUnique)
                        if (!UniqueSymbols.Contains(j)) UniqueSymbols.Add(j);
                }
            }
            Console.WriteLine($"Unique symbols used: {UniqueSymbols.Count}");
            for (int i = 0; i < Numbers.Length; i++)
            {
                for (int j = 0; j < Numbers[i]; j++)
                {
                    Console.Write(Words[i]);
                }
            }
            Console.WriteLine();
        }
    }
}
