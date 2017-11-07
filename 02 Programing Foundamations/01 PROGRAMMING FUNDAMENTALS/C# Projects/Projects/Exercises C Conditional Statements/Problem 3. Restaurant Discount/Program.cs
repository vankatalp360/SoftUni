using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3.Restaurant_Discount
{
    class Program
    {
        static void Main(string[] args)
        {
            int GroupSize = int.Parse(Console.ReadLine());
            string ServicePackageType = Console.ReadLine();


            string HallType = null;
            int HallPrice = 0;
            if (GroupSize <= 50) { HallType = "Small Hall"; HallPrice = 2500; }
            else if (GroupSize <= 100) { HallType = "Terrace"; HallPrice = 5000; }
            else if (GroupSize <= 120) { HallType = "Great Hall"; HallPrice = 7500; }
            else { Console.WriteLine("We do not have an appropriate hall."); return; }
            var DiscountAndPackagePrice = CalculateDiscountAndPackagePrice(ServicePackageType);
            double CostPearPerson = (HallPrice + DiscountAndPackagePrice.Item2) * (1 - DiscountAndPackagePrice.Item1) / GroupSize;
            Console.WriteLine($"We can offer you the {HallType}");
            Console.WriteLine($"The price per person is {CostPearPerson:f2}$");
        }
        private static Tuple<double, int> CalculateDiscountAndPackagePrice(string ServicePackageType)
        {
            double Discount = 0;
            int Price = 0;
            switch (ServicePackageType)
            {
                case "Normal":
                    Discount = 5.0d / 100;
                    Price = 500;
                    break;
                case "Gold":
                    Discount = 10.0d / 100;
                    Price = 750;
                    break;
                case "Platinum":
                    Discount = 15.0d / 100;
                    Price = 1000;
                    break;
                default:
                    Console.WriteLine("Incorrect Package Type! Incorrect calculations!");
                    break;
            }
            return Tuple.Create(Discount, Price);
        }
    }
}
