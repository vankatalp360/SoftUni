using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] separators = { ' ', ',', '.', '?', '!' };
            string[] inputText = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries).ToArray();
            List<string> outputText = new List<string>();
            foreach (var word in inputText)
            {
                if (word == string.Join("", word.ToCharArray().Reverse().ToArray())) outputText.Add(word);
            }
            Console.WriteLine(string.Join(", ", outputText.OrderBy(x => x).Distinct()));
        }
    }
}
