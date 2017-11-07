using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_5.Magic_exchangeable_words
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();
            StringsExchangeable(input[0], input[1]);
        }

        private static void StringsExchangeable(string v1, string v2)
        {
            bool result = false;
            int minLenght = Math.Min(v1.Length, v2.Length);
            if (v1.Length == v2.Length)
            {
                result = SameLenghtStringsExchangeable(v1, v2, minLenght);
            }
            else
            {
                result = DifLenghtStringsExchangeable(v1, v2, minLenght);
            }
            if (result)
                Console.WriteLine("true");
            else
                Console.WriteLine("false");
        }

        private static bool DifLenghtStringsExchangeable(string v1, string v2, int minLenght)
        {
            string first = v1.Substring(0, minLenght);
            string second = v2.Substring(0, minLenght);
            if (SameLenghtStringsExchangeable(first, second, minLenght))
            {
                if (v1.Length > v2.Length)
                {
                    string extention = v1.Substring(minLenght);
                    List<char> letters = extention.ToCharArray().Distinct().ToList();
                    if (StringContainsLettes(first, letters, second)) return true;
                }
                else
                {
                    string extention = v2.Substring(minLenght);
                    List<char> letters = extention.ToCharArray().Distinct().ToList();
                    if (StringContainsLettes(second, letters, first)) return true;
                }
            }
            return false;
        }

        private static bool StringContainsLettes(string first, List<char> letters, string second)
        {
            foreach (char letter in letters)
            {
                if (!first.Contains(letter))
                {
                    if (!second.Contains(letter))
                        return false;
                }
            }
            return true;
        }

        private static bool SameLenghtStringsExchangeable(string v1, string v2, int max)
        {
            for (int i = 0; i < max; i++)
            {
                char v1letter = v1[i];
                char v2letter = v2[i];
                for (int j = i; j < max; j++)
                {
                    if (v1letter == v1[j] && v2letter != v2[j]) return false;
                }
            }
            return true;
        }
    }
}
