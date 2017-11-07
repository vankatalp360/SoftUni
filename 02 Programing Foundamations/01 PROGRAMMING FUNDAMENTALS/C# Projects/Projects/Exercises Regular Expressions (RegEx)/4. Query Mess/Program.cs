using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _4.Query_Mess
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END") break;
                input = input.Replace("%20", " ");
                input = input.Replace("+", " ");
                string pattern = @"(^|\&|\?)?(?<field>[^\?\&]*)\=(?<value>[^\?\&]*)($|\&|\?)?";
                MatchCollection matches = Regex.Matches(input, pattern);
                Dictionary<string, List<string>> fieldAndKeys = new Dictionary<string, List<string>>();
                foreach(Match match in matches)
                {
                    var field = match.Groups["field"].ToString();
                    var value = match.Groups["value"].ToString();
                    string[] velueWords = value.Split(new char []{ ' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    value = string.Join(" ",velueWords);
                    if (!fieldAndKeys.ContainsKey(field.Trim())) fieldAndKeys[field.Trim()] = new List<string>() { value};
                    else fieldAndKeys[field.Trim()].Add(value);
                }
                foreach(var pair in fieldAndKeys)
                {
                    Console.Write($"{pair.Key}=[{string.Join(", ",pair.Value. Distinct())}]");
                }
                Console.WriteLine();
            }
        }
    }
}
