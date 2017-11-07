using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.Key_Replacer
{
    class Program
    {
        static void Main(string[] args)
        {
            string patternKeys = @"^(?<start>([A-Za-z^\||\<|\\])+?)(\||\<|\\)(?<body>.*)(\||\<|\\)(?<end>[A-Za-z^\||\<|\\]+?)$";
            string keys = Console.ReadLine();
            Match match = Regex.Match(keys, patternKeys);
            string start = match.Groups["start"].ToString();
            string end = match.Groups["end"].ToString();
            string text = Console.ReadLine();
            string pattern = $@"(?<={start})(.*?)(?={end})";
            List<string> matches = Regex.Matches(text, pattern)
                 .Cast<Match>()
                 .Select(x => x.Value.Trim())
                 .Where(x=>x!="")                                 
                 .Distinct()
                 .ToList();
            if (matches.Count != 0)
                Console.WriteLine(string.Join("", matches));
            else
                Console.WriteLine("Empty result");
        }
    }
}
