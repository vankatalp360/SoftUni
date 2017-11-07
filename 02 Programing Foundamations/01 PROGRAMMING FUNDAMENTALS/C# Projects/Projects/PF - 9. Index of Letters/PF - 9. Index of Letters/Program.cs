using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___9.Index_of_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] Array = new char[26];
            int j = 0;
            for (char a = 'a'; a <= 'z'; a++)
            {
                Array[j] = a;
                j++;
            }
            string word = Console.ReadLine();
            for (int i = 0; i < word.Length; i++)
            {
                for (int b = 0; b < Array.Length; b++)
                {
                    if (word[i] == Array[b]) Console.WriteLine($"{word[i]} -> {b}");
                }
            }
        }
    }
}
