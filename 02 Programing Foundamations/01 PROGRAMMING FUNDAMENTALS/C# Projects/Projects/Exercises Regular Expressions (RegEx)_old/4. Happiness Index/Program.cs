using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _4.Happiness_Index
{
    class Program
    {
        static void Main(string[] args)
        {
            string patternHappyEmotion = @"([:][)\]}*D])|([;][)\]}])|([(*c[][:])|([[][;])";
            string patternUnhappyEmotion = @"([:][[{c(])|([;][\([{])|([\]D)][:])|([\]][;])";
            string text = Console.ReadLine();
            MatchCollection happyCollection = Regex.Matches(text, patternHappyEmotion);
            MatchCollection unhappyCollection = Regex.Matches(text, patternUnhappyEmotion);
            double happinesIndex = (double)happyCollection.Count / unhappyCollection.Count;
            string sign;
            if (happinesIndex >= 2) sign = ":D";
            else if (happinesIndex > 1) sign = ":)";
            else if (happinesIndex == 1) sign = ":|";
            else sign = ":(";
            Console.WriteLine($"Happiness index: {happinesIndex:f2} {sign}");
            Console.WriteLine($"[Happy count: {happyCollection.Count}, Sad count: {unhappyCollection.Count}]");
        }
    }
}
