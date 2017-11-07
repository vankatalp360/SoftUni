using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _3.Match_Hexadecimal_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = @"(\b(?:0x)?[0-9A-F]+\b)";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(text);
            List<string> answer = new List<string>();
            foreach (Match match in matches)
            {
                answer.Add(match.Groups[0].ToString());
            }
            Console.WriteLine(string.Join(" ", answer));
        }
    }
}
