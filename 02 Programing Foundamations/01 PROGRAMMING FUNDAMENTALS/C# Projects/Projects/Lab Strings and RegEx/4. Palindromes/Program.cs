using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _4.Palindromes
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = @"[^\ \,\.\?\!]*";
            string[] matches = Regex.Matches(text, pattern)
                .Cast<Match>()
                .Select(x => x.Value.Trim())
                .ToArray()
                .Where(x => x == string.Join("", x.Reverse()))
                .Where(x => x != "")
                .OrderBy(x => x)
                .Distinct()
                .ToArray();
            Console.WriteLine(string.Join(", ", matches));
        }
    }
}
