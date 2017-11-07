using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PF_Exam___09_July_2017_Part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string patternDidimon = @"[^A-Za-z-]+";
            string patternBojomon = @"([A-Za-z]+-[A-Za-z]+)";
            string input = Console.ReadLine();
            while (true)
            {
                if (input.Length == 0) break;
                Match matchDidimon = Regex.Match(input, patternDidimon);
                if (!matchDidimon.Success)
                {
                    break;
                }
                else
                {
                    string currentWord = matchDidimon.Groups[0].Value;
                    Console.WriteLine(currentWord);
                    int indexCurrentWord = input.IndexOf(currentWord);
                    input = input.Substring(indexCurrentWord + currentWord.Length);
                }
                Match matchBojomon = Regex.Match(input, patternBojomon);
                if (!matchBojomon.Success)
                {
                    break;
                }
                else
                {
                    string currentWord = matchBojomon.Groups[0].Value;
                    Console.WriteLine(currentWord);
                    int indexCurrentWord = input.IndexOf(currentWord);
                    input = input.Substring(indexCurrentWord + currentWord.Length);
                }
            }
        }
    }
}
