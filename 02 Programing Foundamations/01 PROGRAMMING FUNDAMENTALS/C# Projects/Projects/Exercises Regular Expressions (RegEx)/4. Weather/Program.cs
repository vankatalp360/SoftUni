using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Weather
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            //string pattern = @"(?<cityCode>[A-Z]{2})(?<averageTemp>\+?((\d*\.\d{1,2})|(\d+\.\d{0,2})))(?<weatherType>[A-Za-z]+)(?=\|)";
            string pattern = @"(?<cityCode>[A-Z]{2})(?<averageTemp>\d*.\d{1,2})(?<weatherType>[A-Za-z]+)(?=\|)";

            Dictionary<string, Dictionary<double, string>> citiesInfo = new Dictionary<string, Dictionary<double, string>>();
            
            while (true)
            {
                string text = Console.ReadLine();

                if (text == "end")
                    break;

                MatchCollection matches = Regex.Matches(text, pattern);

                foreach (Match match in matches)
                {
                    string cityCode = match.Groups["cityCode"].ToString();

                    double averageTemp = double.Parse(match.Groups["averageTemp"].ToString());

                    //if (averageTemp > 50) continue;

                    string weatherType = match.Groups["weatherType"].ToString();

                    if (!citiesInfo.ContainsKey(cityCode))
                    {
                        citiesInfo[cityCode] = new Dictionary<double, string>();
                        citiesInfo[cityCode][averageTemp] = weatherType;
                        continue;
                    }

                    citiesInfo[cityCode].Remove(citiesInfo[cityCode].First().Key);

                    citiesInfo[cityCode][averageTemp] = weatherType;
                }
            }
            foreach (var pair in citiesInfo.OrderBy(x => x.Value.First().Key))
            {
                foreach (var temp in pair.Value)
                {
                    Console.WriteLine($"{pair.Key} => {temp.Key:f2} => {temp.Value}");
                }
            }
        }
    }
}
