using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Dictionaries__Lambda_and_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            List<double> numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToList();
            Dictionary<double, int> outputNumbers = new Dictionary<double, int>();
            foreach (var number in numbers)
            {
                if (outputNumbers.ContainsKey(number))
                {
                    outputNumbers[number]++;
                }
                else outputNumbers[number] = 1;
            }
            foreach (var pair in outputNumbers.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }
    }
}
