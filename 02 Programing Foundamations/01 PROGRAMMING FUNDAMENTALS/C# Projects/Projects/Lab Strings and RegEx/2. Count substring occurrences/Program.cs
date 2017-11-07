using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Count_substring_occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine().ToLower();
            string sample = Console.ReadLine().ToLower();
            string pattern = $@"(?<=({sample}))";
            MatchCollection matches = Regex.Matches(text, pattern);
            Console.WriteLine(matches.Count);
        }
    }
}
