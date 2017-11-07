using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace More_Exercises_Strings_and_Regex
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string text = Console.ReadLine();
            string replacedText = Regex.Replace(text, word, new string('*', word.Length));
            Console.WriteLine(replacedText);
        }
    }
}
