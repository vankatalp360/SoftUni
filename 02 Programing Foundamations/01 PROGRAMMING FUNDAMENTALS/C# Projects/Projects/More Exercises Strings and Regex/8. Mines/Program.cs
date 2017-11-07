using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _8.Mines
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = @"\<(?<mine>(.){2})\>";
            while (Regex.IsMatch(text, pattern))
            {
                Match match = Regex.Match(text, pattern);
                string current = match.Groups["mine"].Value;
                int number = Math.Abs(current[0] - current[1]);
                string[] sep = Regex.Split(text, $@"\<{current}\>");
                int startLeft = sep[0].Length - number;
                if (startLeft < 0) startLeft = 0;
                char[] left = sep[0].ToCharArray().Take(startLeft).ToArray();
                string rest = text.Substring(sep[0].Length + 4);
                if (number > rest.Length) number = rest.Length;
                char[] right = rest.ToCharArray().Skip(number).Take(rest.Length - number).ToArray();
                text = string.Join("", left) + new string('_', text.Length - right.Length - left.Length) + string.Join("", right);
            }
            Console.WriteLine(text);
        }
    }
}
