using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _4.Match_Dates_Rev2
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = @"\b(?<days>\d{2})([\-.\/])(?<months>[A-Z][a-z]{2})\1(?<years>\d{4})\b";
            MatchCollection matches = Regex.Matches(text, pattern);
            foreach(Match match in matches)
            {
                string day = match.Groups["days"].Value;
                string month = match.Groups["months"].Value;
                string year = match.Groups["years"].Value;
                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}
