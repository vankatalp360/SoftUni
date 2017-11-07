using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3.Football_Standings
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine();
            int keyLenght = key.Length;
            Dictionary<string, int[]> scoreTable = new Dictionary<string, int[]>();
            while (true)
            {
                string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (input[0] == "final") break;
                string firstTeamName = DecryptTeamName(key, input[0], keyLenght).ToUpper();
                string secondTeamName = DecryptTeamName(key, input[1], keyLenght).ToUpper();
                int[] result = input[2].Split(':').Select(int.Parse).ToArray();
                int firstTeamFoals = result[0];
                int secondTeamFoals = result[1];
                FileTeamResult(scoreTable, firstTeamName, firstTeamFoals, secondTeamFoals);
                FileTeamResult(scoreTable, secondTeamName, secondTeamFoals, firstTeamFoals);
            }
            PrintResult(scoreTable);
        }

        private static void PrintResult(Dictionary<string, int[]> scoreTable)
        {
            Console.WriteLine("League standings:");
            int counter = 1;
            foreach (var team in scoreTable.OrderByDescending(x => x.Value[0]).ThenBy(x=>x.Key))
            {
                Console.WriteLine($"{counter}. {team.Key} {team.Value[0]}");
                counter++;
            }
            Console.WriteLine("Top 3 scored goals:");
            foreach (var team in scoreTable.OrderByDescending(x => x.Value[1]).ThenByDescending(x => x.Value[0]).ThenBy(x => x.Key).Take(3))
            {
                Console.WriteLine($"- {team.Key} -> {team.Value[1]}");
            }
        }

        private static void FileTeamResult(Dictionary<string, int[]> scoreTable, string firstTeamName, int firstTeamFoals, int secondTeamFoals)
        {
            if (!scoreTable.ContainsKey(firstTeamName))
            {
                scoreTable[firstTeamName] = new int[2];
            }
            if (firstTeamFoals > secondTeamFoals)
            {
                scoreTable[firstTeamName][0] += 3;
            }
            else if (firstTeamFoals == secondTeamFoals)
            {
                scoreTable[firstTeamName][0] += 1;
            }
            scoreTable[firstTeamName][1] += firstTeamFoals;
        }

        private static string DecryptTeamName(string key, string text, int keyLenght)
        {
            int firstApperance = text.IndexOf(key);
            int lastApperance = text.LastIndexOf(key);
            string teamName = string.Join("", text
                .Skip(firstApperance + keyLenght)
                .Take(lastApperance - firstApperance - keyLenght)
                .Reverse()
                .ToArray());
            return teamName;
        }
    }
}
