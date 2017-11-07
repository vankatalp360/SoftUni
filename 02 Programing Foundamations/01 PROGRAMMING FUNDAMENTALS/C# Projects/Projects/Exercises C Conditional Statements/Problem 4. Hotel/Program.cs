using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4.Hotel
{
    class Program
    {
        static void Main(string[] args)
        {
            string Month = Console.ReadLine();
            int NightsCount = int.Parse(Console.ReadLine());
            int StudioCost = CalculatePricesAboutRooms(Month).Item1;
            int DoubleCost = CalculatePricesAboutRooms(Month).Item2;
            int SuiteCost = CalculatePricesAboutRooms(Month).Item3;

            int StudioDiscount = CalculateDiscounts(NightsCount, Month).Item1;
            int DoubleDiscount = CalculateDiscounts(NightsCount, Month).Item2;
            int SuiteDiscount = CalculateDiscounts(NightsCount, Month).Item3;

            int NightsCountForStrudio = NightsCount;
            if (NightsCount > 7 && (Month == "September" || Month == "October")) NightsCountForStrudio = NightsCountForStrudio - 1;

            double StudioTotal = StudioCost * (1 - StudioDiscount / 100.0d) * NightsCountForStrudio;
            double DoubleTotal = DoubleCost * (1 - DoubleDiscount / 100.0d) * NightsCount;
            double SuiteTotal = SuiteCost * (1 - SuiteDiscount / 100.0d) * NightsCount;


            Console.WriteLine($"Studio: {StudioTotal:f2} lv.");
            Console.WriteLine($"Double: {DoubleTotal:f2} lv.");
            Console.WriteLine($"Suite: {SuiteTotal:f2} lv.");
        }

        private static Tuple<int, int, int> CalculatePricesAboutRooms(string Month)
        {
            int Studio = 0;
            int Double = 0;
            int Suite = 0;
            switch (Month)
            {
                case "May":
                case "October":
                    Studio = 50;
                    Double = 65;
                    Suite = 75;
                    break;
                case "June":
                case "September":
                    Studio = 60;
                    Double = 72;
                    Suite = 82;
                    break;
                case "July":
                case "August":
                case "December":
                    Studio = 68;
                    Double = 77;
                    Suite = 89;
                    break;
                default:
                    Console.WriteLine("Incorrect Month! Incorrect calculations!");
                    break;
            }
            return Tuple.Create(Studio, Double, Suite);
        }
        private static Tuple<int, int, int> CalculateDiscounts(int NightsCount, string Month)
        {
            int StudioDiscount = 0;
            int DoubleDiscount = 0;
            int SuiteDiscount = 0;
            if (NightsCount > 7 && (Month == "May" || Month == "October")) StudioDiscount = 5;
            if (NightsCount > 14 && (Month == "June" || Month == "September")) DoubleDiscount = 10;
            if (NightsCount > 14 && (Month == "July" || Month == "August" || Month == "December")) SuiteDiscount = 15;

            return Tuple.Create(StudioDiscount, DoubleDiscount, SuiteDiscount);
        }
    }
}
