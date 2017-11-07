using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Split_by_Word_Casing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> text = Console.ReadLine().Split(new[] { ',', ';', ':', '.', '!', '(', ')', '"', '\'', '\\', '/', '[', ']', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> lowerCaseWords = new List<string>();
            List<string> upperCaseWords = new List<string>();
            List<string> mixedCaseWords = new List<string>();
            foreach (string word in text)
            {
                bool lower = true;
                bool upper = true;
                List<char> letters = new List<char>();
                letters.AddRange(word);

                foreach (var letter in letters)
                {
                    if ((letter < 65 || letter > 90) && (letter < 97 || letter > 122))
                    {
                        lower = false;
                        upper = false;
                        break;
                    }
                    else
                    {
                        if (letter >= 65 && letter <= 90 )
                        {
                            lower = false;
                        }
                        else if (letter >= 97 && letter <= 122 )
                        {
                            upper = false;
                        }
                    }
                }
                if (lower == true && upper == false)
                    lowerCaseWords.Add(word);
                else if (lower == false && upper == true)
                    upperCaseWords.Add(word);
                else
                    mixedCaseWords.Add(word);
            }
            Console.WriteLine($"Lower-case: {string.Join(", ", lowerCaseWords)}");
            Console.WriteLine($"Mixed-case: {string.Join(", ", mixedCaseWords)}");
            Console.WriteLine($"Upper-case: {string.Join(", ", upperCaseWords)}");
        }
    }
}
