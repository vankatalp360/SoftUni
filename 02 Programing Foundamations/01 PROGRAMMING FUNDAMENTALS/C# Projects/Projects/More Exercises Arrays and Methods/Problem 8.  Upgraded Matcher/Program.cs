using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_8.Upgraded_Matcher
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            string[] products = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            long[] quantities = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
            decimal[] prices = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(decimal.Parse).ToArray();
            string[] product = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            while (product[0] != "done")
            {
                int index = Array.IndexOf(products, product[0]);
                long quantity;
                if (index >= quantities.Length) quantity = 0; else quantity = quantities[index];
                long reqQuantity = long.Parse(product[1]);
                if (reqQuantity > quantity)
                {
                    Console.WriteLine($"We do not have enough {products[index]}");
                }
                else
                {
                    Console.WriteLine($"{products[index]} x {reqQuantity} costs {prices[index] * reqQuantity:F2}");
                    if (index < quantities.Length) quantities[index] = quantities[index] - reqQuantity;
                }
                product = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
