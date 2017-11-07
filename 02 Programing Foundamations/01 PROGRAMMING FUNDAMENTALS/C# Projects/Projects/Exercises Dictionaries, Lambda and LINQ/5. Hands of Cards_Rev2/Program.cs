using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> cardsGame = new Dictionary<string, List<string>>();
            while (true)
            {
                string[] input = Console.ReadLine().Trim().Split(':').ToArray();
                if (input[0] == "JOKER") break;
                DefineDictionaryOfPlayerNamesAndCards(cardsGame, input);
            }
            PrintResult(cardsGame);
        }

        private static void PrintResult(Dictionary<string, List<string>> cardsGame)
        {
            foreach (var pair in cardsGame)
            {
                int sum = 0;
                foreach (var card in pair.Value)
                {
                    sum = CalculateSumOfPlayerCards(sum, card);
                }
                Console.WriteLine($"{pair.Key}: {sum}");
            }
        }

        private static int CalculateSumOfPlayerCards(int sum, string signs)
        {
            string power=signs.Substring(0,signs.Length-1);
            string type = signs.Last().ToString();
            sum += CalculateValue(power) * CalculateValue(type);
            return sum;
        }

        private static void DefineDictionaryOfPlayerNamesAndCards(Dictionary<string, List<string>> cardsGame, string[] input)
        {
            List<string> cards = input[1].Trim().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Distinct().ToList();
            if (!cardsGame.ContainsKey(input[0]))
            {
                cardsGame[input[0]] = cards;
            }
            else
            {
                List<string> current = cardsGame[input[0]];
                current.AddRange(cards);
                var final = current.Distinct().ToList();
                cardsGame[input[0]] = final;
            }
        }

        private static int CalculateValue(string word)
        {
            int value;
            bool result = int.TryParse(word, out value);
            if (!result) value = TakeCharValue(word);
            return value;
        }

        private static int TakeCharValue(string word)
        {
            switch (word)
            {
                case "J":
                    return 11;
                case "Q":
                    return 12;
                case "K":
                    return 13;
                case "A":
                    return 14;
                case "S":
                    return 4;
                case "H":
                    return 3;
                case "D":
                    return 2;
                case "C":
                    return 1;
                default:
                    return 0;
            }
        }
    }
}
