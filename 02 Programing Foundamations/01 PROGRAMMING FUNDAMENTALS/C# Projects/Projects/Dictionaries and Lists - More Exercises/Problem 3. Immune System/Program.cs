using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3.Immune_System
{
    class Program
    {
        static void Main(string[] args)
        {
            int initualHealth = int.Parse(Console.ReadLine());
            int currentHealth = initualHealth;
            Dictionary<string, int> defeatedViruses = new Dictionary<string, int>();
            while (true)
            {
                string virus = Console.ReadLine();
                if (virus == "end") break;
                char[] letters = virus.ToCharArray();
                int virusStrength = letters.Select(x => (int)x).Sum() / 3;
                int timeToDefeat;
                if (!defeatedViruses.ContainsKey(virus))
                {
                    timeToDefeat = virusStrength * letters.Length;
                    defeatedViruses[virus] = timeToDefeat;
                }
                else
                {
                    timeToDefeat = virusStrength * letters.Length / 3;
                }
                Console.WriteLine($"Virus {virus}: {virusStrength} => {timeToDefeat} seconds");
                if (currentHealth < timeToDefeat)
                {
                    Console.WriteLine("Immune System Defeated.");
                    return;
                }
                else
                {                    
                    int virusDefeatMinutes = timeToDefeat / 60;
                    int virusDefeatSeconds = timeToDefeat - 60 * virusDefeatMinutes;
                    Console.WriteLine($"{virus} defeated in {virusDefeatMinutes}m {virusDefeatSeconds}s.");
                    currentHealth -= timeToDefeat;
                    Console.WriteLine($"Remaining health: {currentHealth}");
                    if (1.2 * currentHealth < initualHealth) currentHealth = (int)(currentHealth * 1.2);
                    else currentHealth = initualHealth;
                }
            }
            Console.WriteLine($"Final Health: {currentHealth}");
        }
    }
}
