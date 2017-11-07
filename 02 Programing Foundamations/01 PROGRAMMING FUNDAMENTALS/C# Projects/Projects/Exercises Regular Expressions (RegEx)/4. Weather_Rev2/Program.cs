using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _4.Weather_Rev2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string[]> result = new Dictionary<string, string[]>();
            string pattern = @"([A-Z]{2})(\d+.\d+)([A-Za-z]+)\|";
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end") break;
                if (Regex.IsMatch(input, pattern))
                {
                    Match match = Regex.Match(input, pattern);
                    var city = match.Groups[1].Value;
                    var temperature = match.Groups[2].Value;
                    var weather = match.Groups[3].Value;
                    string[] cityInfo = { temperature, weather };
                    result[city] = cityInfo;
                }
            }
            foreach (var pair in result.OrderBy(x => x.Value[0]))
            {
                Console.WriteLine($"{pair.Key} => {double.Parse(pair.Value[0]):f2} => {pair.Value[1]}");
            }
        }
    }
}
