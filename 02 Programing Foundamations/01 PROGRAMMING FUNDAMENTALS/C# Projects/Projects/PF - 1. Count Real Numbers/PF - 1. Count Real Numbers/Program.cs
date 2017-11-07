using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___1.Count_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> RealNumbersList = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToList();
            SortedDictionary<double,int> counts = new SortedDictionary<double, int>();
            foreach (var number in RealNumbersList)
            {
                if (counts.ContainsKey(number))
                {
                    counts[number]++;
                }
                else counts[number] = 1;
            }
            foreach (var num in counts.Keys)
                Console.WriteLine($"{num} -> {counts[num]}");
        }
    }
}
