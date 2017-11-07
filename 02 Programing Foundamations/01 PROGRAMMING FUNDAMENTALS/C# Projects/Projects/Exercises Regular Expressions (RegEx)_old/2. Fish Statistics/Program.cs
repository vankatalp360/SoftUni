using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _2.Fish_Statistics
{
    class Program
    {
        static void Main(string[] args)
        {
            const int lenghtInCantimeters = 2;
            string pattern = @"(?<fish>(?<tail>>*)<(?<body>\(+)(?<status>['\-x])>)";
            MatchCollection fishes = Regex.Matches(Console.ReadLine(), pattern);
            List<string[]> allFishes = ReadAllFishMatches(lenghtInCantimeters, fishes);
            PrintResult(allFishes);
        }

        private static void PrintResult(List<string[]> allFishes)
        {
            int counter = 1;
            if (allFishes.Count == 0)
            {
                Console.WriteLine($"No fish found.");
            }
            else
            {
                foreach (var fish in allFishes)
                {
                    Console.WriteLine($"Fish {counter}: {fish[0]}");
                    if (fish[1] != "None")
                    {
                        Console.WriteLine($"  Tail type: {fish[1]} ({fish[2]} cm)");
                    }
                    else
                        Console.WriteLine($"  Tail type: {fish[1]}");
                    Console.WriteLine($"  Body type: {fish[3]} ({fish[4]} cm)");
                    Console.WriteLine($"  Status: {fish[5]}");
                    counter++;
                }
            }
        }

        private static List<string[]> ReadAllFishMatches(int lenghtInCantimeters, MatchCollection fishes)
        {
            List<string[]> allFishes = new List<string[]>();
            foreach (Match currentFish in fishes)
            {
                string[] currentStatus = new string[6];
                var fish = currentFish.Groups["fish"].Value;
                var tail = currentFish.Groups["tail"].Value;
                var body = currentFish.Groups["body"].Value;
                var status = currentFish.Groups["status"].Value;
                currentStatus[0] = fish;
                if (tail.Length > 5) currentStatus[1] = "Long";
                else if (tail.Length > 1) currentStatus[1] = "Medium";
                else if (tail.Length == 1) currentStatus[1] = "Short";
                else currentStatus[1] = "None";
                currentStatus[2] = (tail.Length * lenghtInCantimeters).ToString();
                if (body.Length > 10) currentStatus[3] = "Long";
                else if (body.Length > 5) currentStatus[3] = "Medium";
                else currentStatus[3] = "Short";
                currentStatus[4] = (body.Length * lenghtInCantimeters).ToString();
                if (status == "'") currentStatus[5] = "Awake";
                else if (status == "-") currentStatus[5] = "Asleep";
                else currentStatus[5] = "Dead";
                allFishes.Add(currentStatus);
            }
            return allFishes;
        }
    }
}
