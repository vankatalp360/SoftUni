using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4.Supermarket_Database
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            Dictionary<string, double> productsAndPrices = new Dictionary<string, double>();
            Dictionary<string, int> productsAndQuantities = new Dictionary<string, int>();
            while (true)
            {
                string[] products = Console.ReadLine().Split(' ').ToArray();
                if (products[0] == "stocked") break;
                productsAndPrices[products[0]] = double.Parse(products[1]);
                if (!productsAndQuantities.ContainsKey(products[0]))
                    productsAndQuantities[products[0]] = int.Parse(products[2]);
                else
                    productsAndQuantities[products[0]] += int.Parse(products[2]);
            }
            double total=0;
            foreach (var products in productsAndPrices)
            {
                Console.WriteLine($"{products.Key}: ${products.Value:F2} * {productsAndQuantities[products.Key]} = ${productsAndQuantities[products.Key] * products.Value:F2}");
                double current = productsAndQuantities[products.Key] * products.Value;
                total += productsAndQuantities[products.Key] * products.Value;
            }
            Console.WriteLine($"------------------------------");
            Console.WriteLine($"Grand Total: ${total:F2}");
        }
    }
}
