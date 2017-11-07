using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _6.Match_phone_number
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<=^|\ )\+359(\ |\-)2\1\d{3}\1\d{4}\b";
            string[] matches = Regex.Matches(Console.ReadLine(), pattern)
                .Cast<Match>()
                .Select(x => x.Value)
                .ToArray();
            Console.WriteLine(string.Join(", ",matches));
        }
    }
}
