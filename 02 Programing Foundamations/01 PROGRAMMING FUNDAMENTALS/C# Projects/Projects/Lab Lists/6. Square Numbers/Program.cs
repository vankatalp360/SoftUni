using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Square_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            List<string> inputNumbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<int> squareNumbers = new List<int>();
            foreach (string value in inputNumbers)
            {
                int number;
                bool result = Int32.TryParse(Math.Sqrt(double.Parse(value)).ToString(), out number);
                if (result) squareNumbers.Add(int.Parse(value));
            }
            squareNumbers.Sort();
            squareNumbers.Reverse();
            Console.WriteLine(string.Join(" ", squareNumbers));
        }
    }
}
