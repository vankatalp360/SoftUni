using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exercises_Regular_Expressions__RegEx_
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(^|(?<=\s))([A-Za-z0-9]+)[\.\-_]*([A-Za-z0-9]+)@[A-Za-z\-]+(\.[A-Za-z\-]+)+";
            string text = Console.ReadLine();
            string[] emails = Regex.Matches(text, pattern).Cast<Match>().Select(a => a.Value.Trim()).ToArray();
            Console.WriteLine(string.Join("\r\n",emails));
        }
    }
}
