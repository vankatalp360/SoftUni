using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _4.Match_Dates
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = @"\b\d{2}([^\w]{1})[A-Z]+[a-z]{2}\1\d{4}";
            var dates = Regex.Matches(text, pattern)
                .Cast<Match>()
                .Select(x=>x.Value.Trim())
                .ToArray();
            Console.WriteLine(string.Join(" ", dates));
        }
    }
}
