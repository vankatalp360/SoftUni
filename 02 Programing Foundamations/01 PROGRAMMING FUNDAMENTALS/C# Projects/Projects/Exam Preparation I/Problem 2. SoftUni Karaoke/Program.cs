using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem_2.SoftUni_Karaoke
{
    class Program
    {
        static void Main(string[] args)
        {
            //string pattern = @"\, +";
            //string[] participants = Regex.Split(Console.ReadLine(), pattern);
            //string[] songs = Regex.Split(Console.ReadLine(), pattern);

            string[] participants = Console.ReadLine().Split(',').Select(x=>x.TrimStart()).ToArray();
            string[] songs = Console.ReadLine().Split(',').Select(x => x.TrimStart()).ToArray();

            Dictionary<string, List<string>> storage = new Dictionary<string, List<string>>();
            //string patternInput = @"\, +";
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "dawn") break;
                string[] results = input.Split(',').Select(x => x.TrimStart()).ToArray();
                string singer = results[0];
                string song = results[1];
                string award = results[2];
                if (!participants.Contains(singer)) continue;
                if (!songs.Contains(song)) continue;
                if (!storage.ContainsKey(singer))
                {
                    storage[singer] = new List<string>();
                }
                if (!storage[singer].Contains(award))
                {
                    storage[singer].Add(award);
                }
            }
            if (storage.Values.Count != 0)
            {
                foreach (var singer in storage.OrderByDescending(pair => pair.Value.Count).ThenBy(x => x.Key))
                {

                    Console.WriteLine($"{singer.Key}: {singer.Value.Count} awards");

                    foreach (var award in singer.Value.OrderBy(x => x))
                    {
                        Console.WriteLine($"--{award}");
                    }
                }
            }
            else
            {
                Console.WriteLine($"No awards");
            }
        }
    }
}
