using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_14.Dragon_Army
{

    class Program
    {
        public const int healthConst = 250;
        public const int damageConst = 45;
        public const int armorConst = 10;
        static void Main(string[] args)
        {
            int numberOfDragons = int.Parse(Console.ReadLine());
            Dictionary<string, SortedDictionary<string, int[]>> Dragons = new Dictionary<string, SortedDictionary<string, int[]>>();
            for (int i = 1; i <= numberOfDragons; i++)
            {
                string[] inputData = Console.ReadLine().Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string type, name;
                int[] stats;
                DefineTheDragonData(inputData, out type, out name, out stats);
                DefineTheDragons(Dragons, type, name, stats);
            }
            PrintTheDragos(Dragons);
        }

        private static void DefineTheDragonData(string[] inputData, out string type, out string name, out int[] stats)
        {
            type = inputData[0];
            name = inputData[1];
            stats = DefineTheDragonStats(inputData);
        }

        private static int[] DefineTheDragonStats(string[] inputData)
        {
            int damage, health, armor;
            if (inputData[2] == "null") damage = damageConst; else damage = int.Parse(inputData[2]);
            if (inputData[3] == "null") health = healthConst; else health = int.Parse(inputData[3]);
            if (inputData[4] == "null") armor = armorConst; else armor = int.Parse(inputData[4]);
            int[] stats = new int[] { damage, health, armor };
            return stats;
        }

        private static void PrintTheDragos(Dictionary<string, SortedDictionary<string, int[]>> Dragons)
        {
            foreach (var pair in Dragons)
            {
                SortedDictionary<string, int[]> current = pair.Value;
                double typeDamage = current.Values.Average(x => x[0]);
                double typeHealth = current.Values.Average(x => x[1]);
                double typeArmor = current.Values.Average(x => x[2]);
                Console.WriteLine($"{pair.Key}::({typeDamage:F2}/{typeHealth:F2}/{typeArmor:F2})");
                foreach (var dragon in current)
                {
                    Console.WriteLine($"-{dragon.Key} -> damage: {dragon.Value[0]}, health: {dragon.Value[1]}, armor: {dragon.Value[2]}");
                }
            }
        }

        private static void DefineTheDragons(Dictionary<string, SortedDictionary<string, int[]>> Dragons, string type, string name, int[] stats)
        {
            if (Dragons.ContainsKey(type))
            {
                SortedDictionary<string, int[]> CurrentType = Dragons[type];
                CurrentType[name] = stats;
            }
            else
            {
                SortedDictionary<string, int[]> newType = new SortedDictionary<string, int[]>();
                newType[name] = stats;
                Dragons.Add(type, newType);
            }
        }
    }
}
