using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_5.Weather_Forecast
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputNumber = Console.ReadLine();
            try
            {
                sbyte number = sbyte.Parse(inputNumber);
                Console.WriteLine("Sunny");
            }
            catch
            {
                try
                {
                    int number = int.Parse(inputNumber);
                    Console.WriteLine("Cloudy");
                }
                catch
                {
                    try
                    {
                        long number = long.Parse(inputNumber);
                        Console.WriteLine("Windy");
                    }
                    catch
                    {
                        double number = double.Parse(inputNumber);
                        Console.WriteLine("Rainy");
                    }
                }
            }
        }
    }
}
