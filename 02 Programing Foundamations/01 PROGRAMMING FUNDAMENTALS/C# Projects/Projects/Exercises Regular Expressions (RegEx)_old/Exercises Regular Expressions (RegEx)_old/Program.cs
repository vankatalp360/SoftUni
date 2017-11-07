using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exercises_Regular_Expressions__RegEx__old
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<power>\d+|[JQKA]+)(?<suit>[SHDC])";
            MatchCollection matches = Regex.Matches(Console.ReadLine(), pattern);
            List<string> result = new List<string>();
            foreach(Match match in matches)
            {
                string power = match.Groups["power"].Value;
                string suit = match.Groups["suit"].Value;
                int number;
                bool parst = int.TryParse(power, out number);
                if (parst==true)
                {
                    if (number >= 2 && number <= 10) result.Add(match.Groups[0].Value);
                }
                else if (power=="J"|| power == "Q" || power == "K" || power == "A") result.Add(match.Groups[0].Value);
            }
            Console.WriteLine(string.Join(", ",result));
        }
    }
}
