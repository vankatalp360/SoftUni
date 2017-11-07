using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_13.Сръбско_Unleashed_Rev2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> venueAndParties = new Dictionary<string, Dictionary<string, long>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End") break;
                string[] words = input.Split(' ').ToArray();
                if (words.Length < 4) continue;
                int indexWord, index;
                CalculateWhereIsTheSign(words, out indexWord, out index);
                if (index != 0) continue;
                if (indexWord == 0 || indexWord > 4) continue;
                string[] singerWords = words.Take(indexWord - 1).ToArray();
                if (singerWords.Length >= 4) continue;
                string[] venueWords = words.Skip(indexWord - 1).Take(words.Length - indexWord - 1).ToArray();
                if (venueWords.Length >= 4) continue;
                int ticketPrice;
                if (!CheckTickets(words[words.Length - 2], out ticketPrice)) continue;
                int ticketCount;
                if (!CheckTickets(words[words.Length - 1], out ticketCount)) continue;
                long totalSum = (long)ticketCount * ticketPrice;
                string singer = string.Join(" ", singerWords);
                string venue = string.Join(" ", venueWords);
                venue = venue.Substring(1);
                DefineTheDictionary(venueAndParties, totalSum, singer, venue);
            }
            PrintResult(venueAndParties);
        }

        private static void DefineTheDictionary(Dictionary<string, Dictionary<string, long>> venueAndParties, long totalSum, string singer, string venue)
        {
            if (!venueAndParties.ContainsKey(venue))
            {
                venueAndParties[venue] = new Dictionary<string, long>();
            }
            if (!venueAndParties[venue].ContainsKey(singer))
            {
                venueAndParties[venue][singer] = 0;
            }
            venueAndParties[venue][singer] += totalSum;
        }

        private static void CalculateWhereIsTheSign(string[] words, out int indexWord, out int index)
        {
            indexWord = 0;
            index = 0;
            foreach (var word in words)
            {
                indexWord++;
                if (word.Contains('@'))
                {
                    index = word.IndexOf('@');
                    break;
                }
            }
        }

        private static void PrintResult(Dictionary<string, Dictionary<string, long>> venueAndParties)
        {
            foreach (var kvp in venueAndParties)
            {
                Console.WriteLine($"{kvp.Key}");
                foreach (var pair in kvp.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {pair.Key} -> {pair.Value}");
                }
            }
        }

        private static bool CheckTickets(string word, out int value)
        {
            bool result = int.TryParse(word, out value);
            if (!result)
                return false;
            else
                return true;
        }
    }
}
