using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Logs_Aggregator_Rev2
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] separator = new char[] { ' ' };
            SortedDictionary<string, SortedDictionary<string, int>> UsersNamesIPsAndDurations = new SortedDictionary<string, SortedDictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                string[] currentUser = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (UsersNamesIPsAndDurations.ContainsKey(currentUser[1]))
                {
                    SortedDictionary<string, int> CurrentIPs = UsersNamesIPsAndDurations[currentUser[1]];
                    if (CurrentIPs.ContainsKey(currentUser[0]))
                    {
                        CurrentIPs[currentUser[0]] += int.Parse(currentUser[2]);
                    }
                    else CurrentIPs[currentUser[0]] = int.Parse(currentUser[2]);
                }
                else
                {
                    SortedDictionary<string, int> NewCity = new SortedDictionary<string, int>();
                    NewCity[currentUser[0]] = int.Parse(currentUser[2]);
                    UsersNamesIPsAndDurations.Add(currentUser[1], NewCity);
                }
            }
            foreach (var pair in UsersNamesIPsAndDurations)
            {
                int sum = pair.Value.Sum(x => x.Value);
                Console.Write($"{pair.Key}: {sum} [");
                int count = pair.Value.Count;
                int counter = 1;
                foreach (var value in pair.Value)
                {
                    if (counter != count) Console.Write($"{value.Key}, ");
                    else Console.Write($"{value.Key}");
                    counter++;
                }
                Console.WriteLine("]");
            }
        }
    }
}
