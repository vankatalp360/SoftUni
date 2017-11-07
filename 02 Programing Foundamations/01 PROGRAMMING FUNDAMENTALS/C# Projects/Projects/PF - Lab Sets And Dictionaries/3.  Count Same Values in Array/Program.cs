using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            double[] numbers = Console.ReadLine().Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            Dictionary< double,int> result = new Dictionary<double, int>();
            foreach(double number in numbers)
            {
                if (!result.ContainsKey(number))
                {
                    result[number] = 0;
                }
                result[number] += 1;
            }
            foreach(var pair in result.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{pair.Key} - {pair.Value} times");
            }
        }
    }
}
