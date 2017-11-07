using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4.Beverage_Labels
{
    class Program
    {
        static void Main(string[] args)
        {
            string Name = Console.ReadLine();
            int Volume = int.Parse(Console.ReadLine());
            int Energy = int.Parse(Console.ReadLine());
            int Sugar = int.Parse(Console.ReadLine());
            Console.WriteLine($"{Volume}ml {Name}:");
            Console.WriteLine($"{(decimal)Energy *Volume / 100}kcal, {(decimal)Sugar*Volume / 100}g sugars");
        }
    }
}
