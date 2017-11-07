using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _5.Match_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(^|(?<=\s))-?\d+(\.\d+)?($|(?=\s))";
            string numbers = Console.ReadLine();
            string[] matches = Regex.Matches(numbers, pattern).Cast<Match>().Select(x => x.Value.Trim()).ToArray();
            Console.WriteLine(string.Join(" ", matches));
        }
    }
}
