using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _3.Word_encounter
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char letter = input[0];
            int letterCounter = int.Parse(input.Substring(1));
            List<string> result = new List<string>();
            if (letter >= 0 && letter <= 127)
            {
                string sentancePattern = @"^[A-Z].*[.!?]$";
                Regex regexSentance = new Regex(sentancePattern);
               
                while (true)
                {
                    string sentance = Console.ReadLine();
                    if (sentance == "end") break;
                    if (regexSentance.IsMatch(sentance))
                    {
                        MatchCollection words = Regex.Matches(sentance, @"\w+");
                        foreach (Match word in words)
                        {
                            MatchCollection currentWord = Regex.Matches(word.Groups[0].Value, letter.ToString());
                            if (currentWord.Count>= letterCounter)
                                result.Add(word.Groups[0].Value);
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(", ", result));
        }
    }
}