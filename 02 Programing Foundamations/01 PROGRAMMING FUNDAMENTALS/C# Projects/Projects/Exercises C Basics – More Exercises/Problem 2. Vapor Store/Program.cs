using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Vapor_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            double Money = double.Parse(Console.ReadLine());
            double CurrentMondey = Money;
            while (true)
            {
                string CurrentGame = Console.ReadLine();
                if (CurrentGame == "Game Time")
                {
                    Console.WriteLine($"Total spent: ${(Money - CurrentMondey):f2}. Remaining: ${CurrentMondey:f2}");
                    break;
                }
                if (!DefineIfExist(CurrentGame))
                {
                    Console.WriteLine("Not Found");
                    continue;
                }
                else
                {
                    double CurrentGameUnitPrice = DefineUnitPrice(CurrentGame);
                    if (CurrentMondey < CurrentGameUnitPrice)
                    {
                        Console.WriteLine("Too Expensive");
                        continue;
                    }
                    else
                    {
                        if (CurrentMondey > CurrentGameUnitPrice)
                        {
                            CurrentMondey = CurrentMondey - CurrentGameUnitPrice;
                            Console.WriteLine($"Bought {CurrentGame}");
                        }
                        else
                        {
                            Console.WriteLine("Out of money!");
                            break;
                        }
                    }
                }
            }

        }
        private static bool DefineIfExist(string CurrentGame)
        {
            switch (CurrentGame)
            {
                case "OutFall 4":
                case "CS: OG":
                case "Zplinter Zell":
                case "Honored 2":
                case "RoverWatch":
                case "RoverWatch Origins Edition":
                    return true;
                default:
                    return false;
            }
        }
        private static double DefineUnitPrice(string CurrentGame)
        {
            switch (CurrentGame)
            {
                case "OutFall 4":
                    return 39.99;
                case "CS: OG":
                    return 15.99;
                case "Zplinter Zell":
                    return 19.99;
                case "Honored 2":
                    return 59.99;
                case "RoverWatch":
                    return 29.99;
                case "RoverWatch Origins Edition":
                    return 39.99;
                default:
                    return 0.00;
            }
        }
    }
}
