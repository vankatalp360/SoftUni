using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _5.Use_Your_Chains__Buddy
{
    class Program
    {
        static void Main(string[] args)
        {
            //string text = File.ReadAllText("TextFile1.txt");
            string text = Console.ReadLine();
            string pattern = @"(?<=<\s*p\s*>)(.*?)(?=<\s*\/p\s*>)";
            string []extractedText = Regex.Matches(text, pattern)
                                    .Cast<Match>()
                                    .Select(x => x.Value)
                                    .ToArray();


            string patternCapitalLettersAndDigits = @"[^a-z0-9]";
            Regex rgx = new Regex(patternCapitalLettersAndDigits);
            string patternSpaces = @"\s{2,}";
            Regex rgxS = new Regex(patternSpaces);
           foreach(var ext in extractedText)
            {
                string textWithoutCapitals = rgx.Replace(ext, " ");
                char[] result = rgxS.Replace(textWithoutCapitals, " ").ToCharArray();
                foreach (var letter in result)
                {
                    if (letter >= 'a' && letter <= 'm') Console.Write((char)(letter + ('n' - 'a')));
                    else if (letter >= 'n' && letter <= 'z') Console.Write((char)(letter - ('n' - 'a')));
                    else Console.Write(letter);
                }
            }
            Console.WriteLine();
        }
    }
}
