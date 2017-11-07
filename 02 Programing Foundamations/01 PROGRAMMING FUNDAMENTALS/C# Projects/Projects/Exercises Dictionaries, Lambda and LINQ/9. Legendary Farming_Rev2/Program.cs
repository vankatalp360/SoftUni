using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.Legendary_Farming_Rev2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> Materials = new Dictionary<string, int>() { { "shards", 0 }, { "fragments", 0 }, { "motes", 0 } };
            string[] crushal = { "shards", "fragments", "motes" };
            string artefact = null;
            while (artefact == null)
            {
                string[] input = Console.ReadLine().ToLower().Split(' ').ToArray();
                for (int i = 0; i < input.Length; i += 2)
                {
                    int quantity = int.Parse(input[i]);
                    string material = input[i + 1];
                    if (!Materials.ContainsKey(material))
                    {
                        Materials[material] = quantity;
                    }
                    else
                    {
                        Materials[material] += quantity;
                    }
                    if (Materials[material] >= 250 && crushal.Contains(material))
                    {
                        Materials[material] -= 250;
                        if (material == crushal[0]) artefact = "Shadowmourne";
                        else if (material == crushal[1]) artefact = "Valanyr";
                        else artefact = "Dragonwrath";
                        break;
                    }
                }
            }
            Console.WriteLine($"{artefact} obtained!");
            foreach (var pair in Materials.Where(x => crushal.Contains(x.Key)).OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
            foreach (var pair in Materials.Where(x => !crushal.Contains(x.Key)).OrderBy(x => x.Key))
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }
    }
}
