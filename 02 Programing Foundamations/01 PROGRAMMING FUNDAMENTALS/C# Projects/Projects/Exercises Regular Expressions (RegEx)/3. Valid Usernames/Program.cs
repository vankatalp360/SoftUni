using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b(?<user>[A-Za-z][A-Za-z0-9_]{2,24})\b";
            string text = Console.ReadLine();
            string[] userNames = Regex.Matches(text, pattern)
                .Cast<Match>().Select(a=>a.Groups["user"]. Value.Trim()).ToArray();
            string[] maxSequence = new string[] { userNames[0], userNames[1] };
            for (int i = 2; i < userNames.Length; i++)
            {
                if (userNames[i].Length +
                    userNames[i - 1].Length >
                    maxSequence[0].Length +
                    maxSequence[1].Length)
                {
                    maxSequence[0] = userNames[i - 1];
                    maxSequence[1] = userNames[i];
                }
            }
            foreach (var user in maxSequence)
            {
                Console.WriteLine(user);
            }
        }
    }
}
