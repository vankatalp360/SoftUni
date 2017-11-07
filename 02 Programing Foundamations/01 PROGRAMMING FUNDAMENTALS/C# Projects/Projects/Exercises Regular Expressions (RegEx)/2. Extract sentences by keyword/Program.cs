using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _2.Extract_sentences_by_keyword
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string pattern = $@"(?<sentance>[^\.\?\!]*[^\w\.\?\!]{word}[^\w\.\?\!][^\.\?\!]*)([\.\?\!])";
            string text = Console.ReadLine();
            MatchCollection matches = Regex.Matches(text, pattern);
            foreach(Match match in matches)
            {
                Console.WriteLine(match.Groups["sentance"].Value.Trim());
            }
        }
    }
}
