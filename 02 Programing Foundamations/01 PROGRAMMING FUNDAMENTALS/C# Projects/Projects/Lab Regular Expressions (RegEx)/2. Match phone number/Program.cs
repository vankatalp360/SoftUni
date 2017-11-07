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
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(text);
            List<string> answer = new List<string>();
            foreach(Match match in matches)
            {
                answer.Add(match.Groups[0].ToString());
            }
            Console.WriteLine(string.Join(", ", answer));
        }
    }
}
