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
            List<Sale> sales = new List<Sale>(numberOfSales);
            DefineTheSales(numberOfSales, sales);
            sales = sales.OrderBy(x => x.Town).ToList();
            PrintTheResult(sales);
        }
        
        private static void PrintTheResult(List<Sale> sales)
        {
            foreach (var sale in sales)
            {
                Console.WriteLine($"{sale.Town} -> {sale.TotalSaleSum:f2}");
            }
        }

        private static void DefineTheSales(int numberOfSales, List<Sale> sales)
        {
            for (int i = 0; i < numberOfSales; i++)
            {
                string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                ///<summary>
                ///If there is more than single word for the town!!
                ///currentTown.Town = Enumerable.Range(0, input.Length - 3).Select(p=> input[p]).Aggregate((x,y)=>x+" "+y);
                ///</summary>
                Sale current = new Sale();
                current.Town = input[0];
                current.TotalSaleSum = double.Parse(input[2]) * double.Parse(input[3]);
                AddCurrentTown(sales, i, current);
            }
        }

        private static void AddCurrentTown(List<Sale> sales, int i, Sale current)
        {
            if (i == 0) sales.Add(current);
            else
            {
                bool contains = false;
                for (int j = 0; j < sales.Count; j++)
                {
                    if (sales[j].Town == current.Town)
                    {
                        sales[j].TotalSaleSum += current.TotalSaleSum;
                        contains = true;
                        break;
                    }
                }
                if (contains == false) sales.Add(current);
            }
        }
    }

    class Sale
    {
        public string Town { get; set; }
        public double TotalSaleSum { get; set; }
    }
}
