using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Preparation_III
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            decimal Total = 0;
            for (int i = 1; i <= n; i++)
            {
                decimal price = decimal.Parse(Console.ReadLine());
                int[] DateTime = Console.ReadLine().Split(new char[] { '/' }).Select(int.Parse).ToArray();
                long Capsules = long.Parse(Console.ReadLine());
                int CurrentMonth = DateTime[1];
                int CurrentYear = DateTime[2];
                int DaysOfMonth = System.DateTime.DaysInMonth(CurrentYear, CurrentMonth);
                decimal OrderPrice = (DaysOfMonth * Capsules) * price;
                Console.WriteLine($"The price for the coffee is: ${OrderPrice:f2}");
                Total += OrderPrice;
            }
            Console.WriteLine($"Total: ${Total:f2}");
        }
    }
}
