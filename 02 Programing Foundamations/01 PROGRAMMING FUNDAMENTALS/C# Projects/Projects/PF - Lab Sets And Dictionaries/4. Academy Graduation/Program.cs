using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Academy_Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            int numberOfStudents = int.Parse(Console.ReadLine());
            Dictionary<string, double[]> result = new Dictionary<string, double[]>();
            char[] separator = { ' ' };
            for (int k = 1; k <= numberOfStudents; k++)
            {
                string name = Console.ReadLine();
                double[] score = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
                result[name] = score;
            }
            foreach(var pair in result.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{pair.Key} is graduated with {pair.Value.Average()}");
            }
        }
    }
}
