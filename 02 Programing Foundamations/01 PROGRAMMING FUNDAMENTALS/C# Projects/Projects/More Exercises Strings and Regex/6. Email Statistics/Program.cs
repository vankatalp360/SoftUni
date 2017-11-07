using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _6.Email_Statistics
{
    class Program
    {
        static void Main(string[] args)
        {
            //string pattern = @"(?<username>[A-Za-z]{5,})\@(?<domain>[a-z]{3,}((\.com)|(\.bg)|(\.org))+$)";
            string pattern = @"^(?<username>[A-Za-z]{5,})\@(?<domain>[a-z]{3,}\.(com|bg|org))$";
            int emailNumber = int.Parse(Console.ReadLine());
            Dictionary<string, HashSet<string>> register = new Dictionary<string, HashSet<string>>();
            for (int i = 1; i <= emailNumber; i++)
            {
                Match match = Regex.Match(Console.ReadLine(), pattern);
                if (match.Success)
                {
                    var userName = match.Groups["username"].Value;
                    var domain = match.Groups["domain"].Value;
                    if (!register.ContainsKey(domain))
                    {
                        register[domain] = new HashSet<string>();
                    }
                    register[domain].Add(userName);
                }
            }
            foreach (var domain in register.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{domain.Key}:");
                foreach (var user in domain.Value)
                {
                    Console.WriteLine($"### {user}");
                }
            }
        }
    }
}
