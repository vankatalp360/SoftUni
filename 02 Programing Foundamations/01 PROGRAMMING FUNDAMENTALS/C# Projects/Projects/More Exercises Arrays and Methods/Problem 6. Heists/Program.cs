using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_6.Heists
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] prices = Console.ReadLine().Split();
            int priceOfJew = int.Parse(prices[0]);
            int priceOfGold = int.Parse(prices[1]);
            string command = Console.ReadLine();
            int totalEarnings = 0;
            int expenses = 0;
            while (command != "Jail Time")
            {
                string[] words = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                expenses += int.Parse(words[1]);
                char[] elements = words[0].ToCharArray();
                foreach (var element in elements)
                {
                    if (element == '%') totalEarnings += priceOfJew;
                    if (element == '$') totalEarnings += priceOfGold;
                }
                command = Console.ReadLine();
            }
            if (totalEarnings >= expenses)
                Console.WriteLine($"Heists will continue. Total earnings: {totalEarnings - expenses}.");
            else
                Console.WriteLine($"Have to find another job. Lost: {-(totalEarnings - expenses)}.");
        }
    }
}
