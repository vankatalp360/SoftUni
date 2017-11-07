using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Match_phone_number
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = @"\+(359)( |-)2\2\w{3}\2\w{4}\b";
            string [] matches = Regex.Matches(text, pattern)
                .Cast<Match>().Select(x=>x.Value.Trim()).ToArray() ;
            Console.WriteLine(string.Join(", ", matches));
        }
    }
}
