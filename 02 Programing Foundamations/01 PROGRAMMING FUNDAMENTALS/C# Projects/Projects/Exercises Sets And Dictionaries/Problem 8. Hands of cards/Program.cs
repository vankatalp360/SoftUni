using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_8.Hands_of_cards
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] separator = new char[] { ':' };
            char[] separators = new char[] { ' ', ',' };
            Dictionary<string, List<string>> PlayersAndCards = new Dictionary<string, List<string>>();
            while (true)
            {
                string[] current = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (current[0].ToUpper() == "JOKER") break;
                else
                {
                    string[] currents = current[1].Split(separators, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    if (PlayersAndCards.ContainsKey(current[0]))
                    {
                        List<string> CurrentPlayerCards = PlayersAndCards[current[0]];
                        for (int i = 0; i < currents.Length; i++)
                        {
                            if (!CurrentPlayerCards.Contains(currents[i])) CurrentPlayerCards.Add(currents[i].ToUpper());
                        }
                    }
                    else
                    {
                        List<string> NewPlayerCards = new List<string>();
                        for (int i = 0; i < currents.Length; i++)
                        {
                            if (!NewPlayerCards.Contains(currents[i])) NewPlayerCards.Add(currents[i].ToUpper());
                        }
                        PlayersAndCards.Add(current[0], NewPlayerCards);
                    }
                }
            }
            Dictionary<string, int> PlayersAndScores = new Dictionary<string, int>();
            foreach (var pair in PlayersAndCards)
            {
                int Sum = 0;
                foreach (var value in pair.Value)
                {
                    char[] indexes = value.ToCharArray();
                    int power = 0;
                    if (value.Length > 2) power = 10;
                    else
                    {
                        try
                        {
                            power = int.Parse(indexes[0].ToString());
                        }
                        catch
                        {
                            if (indexes[0] == 'J') power = 11;
                            else if (indexes[0] == 'Q') power = 12;
                            else if (indexes[0] == 'K') power = 13;
                            else if (indexes[0] == 'A') power = 14;
                        }
                    }
                    int type = 0;
                    if (indexes[indexes.Count() - 1] == 'S') type = 4;
                    else if (indexes[indexes.Count() - 1] == 'H') type = 3;
                    else if (indexes[indexes.Count() - 1] == 'D') type = 2;
                    else if (indexes[indexes.Count() - 1] == 'C') type = 1;
                    Sum += type * power;
                }
                PlayersAndScores.Add(pair.Key, Sum);
            }
            foreach (var pair in PlayersAndScores)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }
    }
}
