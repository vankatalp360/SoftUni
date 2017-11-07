using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Population_Counter_Rev2
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, SortedDictionary<string, int>> logs = new SortedDictionary<string, SortedDictionary<string, int>>();
            int number = int.Parse(Console.ReadLine());
            for (int i = 1; i <= number; i++)
            {
                string[] input = Console.ReadLine().Split(' ').ToArray();
                int duration = int.Parse(input[2]);
                if (!logs.ContainsKey(input[1]))
                {
                    logs[input[1]] = new SortedDictionary<string, int>() { { input[0], duration } };
                }
                else
                {
                    SortedDictionary<string, int> current = logs[input[1]];
                    if (!current.ContainsKey(input[0]))
                    {
                        current[input[0]] = duration;
                    }
                    else
                    {
                        current[input[0]] += duration;
                    }
                }
            }
            foreach (var pair in logs)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value.Values.Sum()} [{string.Join(", ", pair.Value.Keys)}]");
            }
        }
    }
}
