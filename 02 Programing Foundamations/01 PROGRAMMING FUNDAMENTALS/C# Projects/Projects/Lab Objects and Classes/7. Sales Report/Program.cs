using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Sales_Report
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            int numberOfSales = int.Parse(Console.ReadLine());
            SortedDictionary<string, double> totalSales = new SortedDictionary<string, double>();
            for (int i = 1; i <= numberOfSales; i++)
            {
                string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                Sale currentTown = new Sale();
                currentTown.Town = input[0];
                currentTown.Product = input[1];
                currentTown.Price = double.Parse(input[2]);
                currentTown.Quantity = double.Parse(input[3]);
                if (totalSales.ContainsKey(currentTown.Town)) totalSales[currentTown.Town] += currentTown.TotalSaleSum;
                else totalSales[currentTown.Town] = currentTown.TotalSaleSum;
            }
            foreach(var pair in totalSales)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value:f2}");
            }

        }
    }

    class Sale
    {
        public string Town { get; set; }
        public string Product { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
        public double TotalSaleSum
        {
            get { return Price * Quantity; }
        }
    }
}
