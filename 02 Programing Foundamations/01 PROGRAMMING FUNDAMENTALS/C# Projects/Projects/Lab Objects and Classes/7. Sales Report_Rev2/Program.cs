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
            Sale[] sales = new Sale[numberOfSales];
            for (int i = 0; i < numberOfSales; i++)
            {
                string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                ///<summary>
                ///If there is more than single word for the town!!
                ///currentTown.Town = Enumerable.Range(0, input.Length - 3).Select(p=> input[p]).Aggregate((x,y)=>x+" "+y);
                ///</summary>
                sales[i] = new Sale();
                sales[i].Town = input[0];
                sales[i].TotalSaleSum = double.Parse(input[2]) * double.Parse(input[3]);
            }
            var towns = sales.Select(s => s.Town).Distinct().OrderBy(t => t);
            foreach (string town in towns)
            {
                double salesByTown = sales.Where(s => s.Town == town)
                  .Select(s => s.TotalSaleSum).Sum();
                Console.WriteLine("{0} -> {1:f2}", town, salesByTown);
            }
        }
    }

    class Sale
    {
        public string Town { get; set; }
        public double TotalSaleSum { get; set; }
    }
}
