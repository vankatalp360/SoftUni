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
            string decryptKey = Console.ReadLine();
            string command = Console.ReadLine();
            Dictionary<string, int> RaitingOrder = new Dictionary<string, int>();
            Dictionary<string, int> ScoreOrder = new Dictionary<string, int>();
            while (command != "final")
            {
                int DecryptKeyLegth = decryptKey.Length;
                int FirstDecryptLetter = command.IndexOf(decryptKey);
                command = command.Substring(FirstDecryptLetter + DecryptKeyLegth, command.Length - (FirstDecryptLetter + DecryptKeyLegth));
                int SecondDecryptLetter = command.IndexOf(decryptKey);
                string FirstTeam = new string(command.Substring(0, SecondDecryptLetter).ToUpper().Reverse().ToArray());
                command = command.Substring(SecondDecryptLetter + DecryptKeyLegth, command.Length - (SecondDecryptLetter + DecryptKeyLegth));
                int ThirdDecryptLetter = command.IndexOf(decryptKey);
                command = command.Substring(ThirdDecryptLetter + DecryptKeyLegth, command.Length - (ThirdDecryptLetter + DecryptKeyLegth));
                int FourthDecryptLetter = command.IndexOf(decryptKey);
                string SecondTeam = new string(command.Substring(0, FourthDecryptLetter).ToUpper().Reverse().ToArray());
                int BreakPoint = command.IndexOf(" ");
                command = command.Substring(BreakPoint + 1, command.Length - (BreakPoint + 1));
                int[] scores = command.TrimStart().Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                ScoreOrder = OrganizeScoreOrder(ScoreOrder, FirstTeam, SecondTeam, scores);
                RaitingOrder = OrganizeRatingOrder(RaitingOrder, FirstTeam, SecondTeam, scores);


                command = Console.ReadLine();
            }
            RaitingOrder = RaitingOrder.OrderByDescending(pair => pair.Value)
            .ThenBy(pair => pair.Key)
            .ToDictionary(pair => pair.Key,
                     pair => pair.Value);
            int j = 1;
            Console.WriteLine("League standings:");
            foreach (var pair in RaitingOrder)
            {
                Console.WriteLine($"{j}. {pair.Key} {pair.Value}");
                j++;
            }
            ScoreOrder = ScoreOrder
            .OrderByDescending(pair => pair.Value)
            .ThenBy(pair => pair.Key)
            .ToDictionary(pair => pair.Key,
                     pair => pair.Value);

            Console.WriteLine("Top 3 scored goals:");
            foreach (var pair in ScoreOrder.Take(Math.Min(3, ScoreOrder.Count)))
            {
                Console.WriteLine($"- {pair.Key} -> {pair.Value}");
            }
        }
        private static Dictionary<string, int> OrganizeRatingOrder(Dictionary<string, int> RaitingOrder, string FirstTeam, string SecondTeam, int[] scores)
        {
            int FirstTeamPoints;
            int SecondTeamPoints;
            if (scores[0] > scores[1]) { FirstTeamPoints = 3; SecondTeamPoints = 0; }
            else if (scores[0] == scores[1]) { FirstTeamPoints = 1; SecondTeamPoints = 1; }
            else { FirstTeamPoints = 0; SecondTeamPoints = 3; }

            if (!RaitingOrder.Keys.Contains(FirstTeam))
            {
                RaitingOrder[FirstTeam] = FirstTeamPoints;
            }
            else
            {
                RaitingOrder[FirstTeam] += FirstTeamPoints;
            }
            if (!RaitingOrder.Keys.Contains(SecondTeam))
            {
                RaitingOrder[SecondTeam] = SecondTeamPoints;
            }
            else
            {
                RaitingOrder[SecondTeam] += SecondTeamPoints;
            }
            return RaitingOrder;
        }

        private static Dictionary<string, int> OrganizeScoreOrder(Dictionary<string, int> ScoreOrder, string FirstTeam, string SecondTeam, int[] scores)
        {
            if (!ScoreOrder.Keys.Contains(FirstTeam))
            {
                ScoreOrder[FirstTeam] = scores[0];
            }
            else
            {
                ScoreOrder[FirstTeam] += scores[0];
            }
            if (!ScoreOrder.Keys.Contains(SecondTeam))
            {
                ScoreOrder[SecondTeam] = scores[1];
            }
            else
            {
                ScoreOrder[SecondTeam] += scores[1];
            }
            return ScoreOrder;
        }
    }
}
