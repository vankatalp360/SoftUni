using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace More_Exercises_Arrays_and_Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int minValue = numbers.Min();
            Console.WriteLine($"Min = {minValue}");
            int maxValue = numbers.Max();
            Console.WriteLine($"Max = {maxValue}");
            int sumValue = numbers.Sum();
            Console.WriteLine($"Sum = {sumValue}");
            double averageValue = numbers.Average();
            Console.WriteLine($"Average = {averageValue}");
        }
    }
}
