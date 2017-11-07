using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.A_Miner_s_Task_Rev2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> Resouces = new Dictionary<string, int>();
            while (true)
            {
                string resource = Console.ReadLine();
                if (resource == "stop") break;
                int amount = int.Parse(Console.ReadLine());
                if (!Resouces.ContainsKey(resource))
                {
                    Resouces[resource] = amount;
                }
                else
                {
                    Resouces[resource] += amount;
                }
            }
            foreach (var pair in Resouces)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }
    }
}
