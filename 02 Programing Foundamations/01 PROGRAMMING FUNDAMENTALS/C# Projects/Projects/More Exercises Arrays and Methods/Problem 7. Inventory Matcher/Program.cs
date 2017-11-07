using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_7.Inventory_Matcher
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            string[] products = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] quantities = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] prices = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string product = Console.ReadLine();
            while (product != "done")
            {
                if (products.Contains(product))
                {
                    int index = Array.IndexOf(products, product);
                    Console.WriteLine($"{products[index]} costs: {prices[index]}; Available quantity: {quantities[index]}");
                }
                product = Console.ReadLine();
            }
        }
    }
}
