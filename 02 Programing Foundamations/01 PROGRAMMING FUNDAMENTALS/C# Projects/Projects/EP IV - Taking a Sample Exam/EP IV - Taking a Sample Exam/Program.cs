using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_IV___Taking_a_Sample_Exam
{
    class Program
    {
        static int bananasPerPosion = 2;
        static int eggsPerPosion = 4;
        static double berriesPerPosion = 0.2;
        static int portions = 6;

        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InstalledUICulture;

            double amountOfCash = double.Parse(Console.ReadLine());
            int numberOfGuests = int.Parse(Console.ReadLine());
            double priceOfBananas = double.Parse(Console.ReadLine());
            double priceOfEggs = double.Parse(Console.ReadLine());
            double priceOfBerries = double.Parse(Console.ReadLine());

            int neededSetOfPorsions = (int)Math.Ceiling((double)numberOfGuests / portions );

            int numberOfBananas = neededSetOfPorsions * bananasPerPosion;
            int numberOfEggs = neededSetOfPorsions * eggsPerPosion;
            double numberOfBerries = neededSetOfPorsions * berriesPerPosion;

            double totalPriceForBananas = numberOfBananas * priceOfBananas;
            double totalPriceForEggs = numberOfEggs * priceOfEggs;
            double totalPriceForBerries = numberOfBerries * priceOfBerries;

            double totalPrice = totalPriceForBerries + totalPriceForBananas + totalPriceForEggs;

            if (amountOfCash>= totalPrice)
            {
                Console.WriteLine($"Ivancho has enough money - it would cost {totalPrice:F2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivancho will have to withdraw money - he will need {(totalPrice-amountOfCash):F2}lv more.");
            }
        }
    }
}
