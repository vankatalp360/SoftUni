using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Choose_a_Drink_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            string Profession = Console.ReadLine();
            int Quantities = int.Parse(Console.ReadLine());
            string Drink = DefineDrink(Profession);
            double TotalPrice = CalculateTotalPrice(Drink, Quantities);
            Console.WriteLine($"The {Profession} has to pay {TotalPrice:f2}.");
        }
        private static string DefineDrink(string Profession)
        {
            switch (Profession)
            {
                case "Athlete":
                    return "Water";
                case "Businessman":
                case "Businesswoman":
                    return "Coffee";
                case "SoftUni Student":
                    return "Beer";
                default:
                    return "Tea";
            }
        }
        private static double CalculateTotalPrice(string Drink, int Quantities)
        {
            double UnitPrice = 0;
            switch (Drink)
            {
                case "Water":
                    UnitPrice = 0.70;
                    break;
                case "Coffee":
                    UnitPrice = 1.00;
                    break;
                case "Beer":
                    UnitPrice = 1.70;
                    break;
                case "Tea":
                    UnitPrice = 1.20;
                    break;
                default:
                    break;
            }
            return UnitPrice * Quantities;
        }
    }
}
