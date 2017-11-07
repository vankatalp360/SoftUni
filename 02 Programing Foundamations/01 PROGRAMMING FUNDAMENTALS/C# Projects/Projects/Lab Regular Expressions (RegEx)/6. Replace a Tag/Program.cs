using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _6.Replace_a_Tag
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<prefix>.*)\<a.*href(?<body1>.*)\>(?<body2>.*)\<\/a>(?<sufix>.*)";
            string result = null;
            while (true)
            {
                result= string.Concat( result,"\r\n");
                string text = Console.ReadLine();
                if (text == "end") break;
                MatchCollection matches = Regex.Matches(text, pattern);
                if (matches.Count!=0)
                {
                    foreach (Match match in matches)
                    {
                        string prefix = match.Groups["prefix"].Value;
                        string body1 = match.Groups["body1"].Value;
                        string body2 = match.Groups["body2"].Value;
                        string sufix = match.Groups["sufix"].Value;
                        result = string.Concat(result,$"{prefix}[URL href{body1}]{body2}[/URL]{sufix}");
                    }
                }
                else
                {
                    result = string.Concat(result,text);
                }               
            }
            Console.WriteLine(result);
        }
    }
}
