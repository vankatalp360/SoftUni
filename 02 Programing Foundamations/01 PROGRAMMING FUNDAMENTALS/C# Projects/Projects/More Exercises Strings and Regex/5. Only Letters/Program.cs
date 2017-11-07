using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _5.Only_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<replacement>(?<number>\d+)(?<letter>[A-Za-z]))";
            string text = Console.ReadLine();
            MatchCollection matches = Regex.Matches(text, pattern);
            foreach (Match match in matches)
            {
                var number = match.Groups["number"].Value;
                var letter = match.Groups["letter"].Value;
                text = Regex.Replace(text, number, letter);
            }
            Console.WriteLine(text);
        }
    }
}
