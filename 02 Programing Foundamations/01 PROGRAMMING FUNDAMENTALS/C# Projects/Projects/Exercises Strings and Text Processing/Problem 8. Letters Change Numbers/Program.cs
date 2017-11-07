using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem_8.Letters_Change_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            decimal sum = 0;
            foreach (string word in words)
            {
                sum += CalculateSum(word);
            }
            Console.WriteLine($"{sum:F2}");
        }

        private static decimal CalculateSum(string word)
        {
            decimal sum = 0;
            string pattern = @"(([A-Za-z]*)([0-9]*)([A-Za-z]*))";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(word);
            foreach (Match match in matches)
            {
                if (match.Length != 0)
                {
                    char[] before = match.Groups[2].ToString().ToCharArray();
                    int number = int.Parse(match.Groups[3].ToString());
                    char[] after = match.Groups[4].ToString().ToCharArray();
                    if (char.IsUpper(before[0]))
                    {
                        sum = (decimal)number / (before[0]-64);
                    }
                    else if (char.IsLower(before[0]))
                    {
                        sum = (decimal)number * (before[0]-96);
                    }

                    if (char.IsUpper(after[0]))
                    {
                        sum = sum - (after[0]-64);
                    }
                    else if (char.IsLower(after[0]))
                    {
                        sum = sum + (after[0]-96);
                    }
                }
            }
            return sum;
        }
    }
}
