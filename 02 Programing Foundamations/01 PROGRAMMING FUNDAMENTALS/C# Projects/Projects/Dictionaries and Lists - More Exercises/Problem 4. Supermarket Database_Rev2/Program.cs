using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4.Supermarket_Database_Rev2
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            Dictionary<string, Dictionary<double, int>> productsLog = new Dictionary<string, Dictionary<double, int>>();
            while (true)
            {
                string[] products = Console.ReadLine().Split(' ').ToArray();
                if (products[0] == "stocked") break;
                string name = products[0];
                double price = double.Parse(products[1]);
                int quantity = int.Parse(products[2]);
                if (!productsLog.ContainsKey(name))
                {
                    productsLog[name] = new Dictionary<double, int>() { { price, quantity } };
                }
                else
                {
                    if (productsLog[name].ContainsKey(price))
                    {
                        productsLog[name][price] += quantity;
                    }
                    else
                    {
                        Dictionary<double, int> previous = new Dictionary<double, int>();
                        foreach (var pair in productsLog[name])
                        {
                            previous[pair.Key] = pair.Value;
                        }
                        productsLog[name].Clear();
                        productsLog[name] = new Dictionary<double, int>();
                        foreach (var pair in previous)
                        {
                            productsLog[name][price] = quantity + pair.Value;
                        }
                    }
                }
            }
            double total = 0;
            foreach (var pair in productsLog)
            {
                foreach (var prices in pair.Value)
                {
                    Console.WriteLine($"{pair.Key}: ${prices.Key:F2} * {prices.Value} = ${prices.Key * prices.Value:F2}");
                    total += prices.Key * prices.Value;
                }
            }
            Console.WriteLine($"------------------------------");
            Console.WriteLine($"Grand Total: ${total:f2}");
        }
    }
}
