using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_7.Training_Hall_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double Budget = double.Parse(Console.ReadLine());
            int numberOfitems = int.Parse(Console.ReadLine());
            double Subtotal = 0;
           for (int i =1; i<=numberOfitems;i++)
            {
                string item = Console.ReadLine();
                double itemPrice = double.Parse(Console.ReadLine());
                int itemCount = int.Parse(Console.ReadLine());
                double ItemTotalCost = itemPrice * itemCount;
                Subtotal += ItemTotalCost;
                Console.WriteLine($"Adding {itemCount} {item}s to cart.");
            }
            Console.WriteLine($"Subtotal: ${Subtotal:f2}");
           if (Subtotal<= Budget)
            {
                Console.WriteLine($"Money left: ${(Budget- Subtotal):F2}");
            }
           else
            {
                Console.WriteLine($"Not enough. We need ${(Subtotal - Budget):F2} more.");
            }
        }
    }
}

