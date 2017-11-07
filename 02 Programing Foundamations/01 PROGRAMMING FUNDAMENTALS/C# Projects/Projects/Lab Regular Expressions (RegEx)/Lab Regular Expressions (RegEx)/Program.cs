using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Regular_Expressions__RegEx_
{
    class Program
    {
        static void Main(string[] args)
        {
            string expresion = Console.ReadLine();
            string pattern = @"\b([A-Z][a-z]+ [A-Z][a-z]+)\b";
            Regex words = new Regex(pattern);

            MatchCollection matches = words.Matches(expresion);

            List<string> answer = new List<string>();
            foreach (Match match in matches)
            {
                answer.Add(match.Groups[0].ToString());
            }
            Console.WriteLine(string.Join(" ", answer));



            //Console.WriteLine("Found {0} matches", matches.Count);
            //foreach (Match match00 in matches)
            //{
            //    Console.WriteLine("Name: {0}", match00.Groups[1]);
            //}
            ////Match match = words.Match(expresion);
            //Console.WriteLine(match.Groups.Count);
            //Console.WriteLine("Matched text: \"{0}\"", match.Groups[0]);
            //Console.WriteLine("Name: {0}", match.Groups[1]);
        }
    }
}
