using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___2.Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> Letters = Console.ReadLine().Split(' ').Select(x => x.ToLower()).ToList();
            Dictionary<string, int> LetterCounter = new Dictionary<string, int>();
            foreach (var number in Letters)
            {
                if (LetterCounter.ContainsKey(number))
                {
                    LetterCounter[number]++;
                }
                else LetterCounter[number] = 1;
            }
            List<string> OddLetters = new List<string>();
            foreach (var i in LetterCounter)
            {
                if (i.Value % 2 == 1)
                {
                    OddLetters.Add(i.Key);
                }
            }
            Console.WriteLine(string.Join(", ",OddLetters));
        }
    }
}
