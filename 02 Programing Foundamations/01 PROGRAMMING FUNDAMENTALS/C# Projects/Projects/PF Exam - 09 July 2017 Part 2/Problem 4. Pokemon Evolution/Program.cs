using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem_4.Pokemon_Evolution
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"( -> )";
            Dictionary<string, List<string[]>> pokemonLog = new Dictionary<string, List<string[]>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "wubbalubbadubdub") break;
                string[] data = Regex.Split(input, pattern);
                if (data.Length == 5)
                {
                    string pokemonName = data[0];
                    string evolutionType = data[2];
                    string evolutionIndex = data[4];
                    if (!pokemonLog.ContainsKey(pokemonName))
                    {
                        pokemonLog[pokemonName] = new List<string[]>();
                    }
                    string[] current = new string[2];
                    current[0] = evolutionType;
                    current[1] = evolutionIndex;
                    pokemonLog[pokemonName].Add(current);
                }
                else
                {
                    string pokemonName = input;
                    if (pokemonLog.ContainsKey(pokemonName))
                    {
                        Console.WriteLine($"# {pokemonName}");
                        foreach (var evolution in pokemonLog[pokemonName])
                        {
                            Console.WriteLine($"{evolution[0]} <-> {evolution[1]}");
                        }
                    }
                }
            }
            foreach (var pokemon in pokemonLog)
            {
                Console.WriteLine($"# {pokemon.Key}");
                foreach (var evolution in pokemon.Value.OrderByDescending(x=>int.Parse(x[1])))
                {
                    Console.WriteLine($"{evolution[0]} <-> {evolution[1]}");
                }
            }
        }
    }
}
