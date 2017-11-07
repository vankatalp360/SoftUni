using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4.Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] chars = Console.ReadLine().ToCharArray();
            Dictionary<char, int> result = new Dictionary<char, int>();
            foreach(var ch in chars)
            {
                if (!result.ContainsKey(ch))
                {
                    result[ch] = 1;
                }
                else
                {
                    result[ch] += 1;
                }
            }
            foreach(var pair in result.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{pair.Key}: {pair.Value} time/s");
            }
        }
    }
}
