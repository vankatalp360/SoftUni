using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carLot = new HashSet<string>();
            while(true)
            {
                string[] input = Console.ReadLine().Split(new char[] { ',' ,' '},StringSplitOptions.RemoveEmptyEntries).ToArray();
                switch (input[0])
                {
                    case "END":
                        PrintResult(carLot);
                        return;
                    case "IN":
                        carLot.Add(input[1]);
                        break;
                    case "OUT":
                        carLot.Remove(input[1]);
                        break;
                }
            }
        }

        static void PrintResult(HashSet<string> carLot)
        {
            if (carLot.Count!=0)
            {
                foreach (string carNumber in carLot.OrderBy(x => x))
                {
                    Console.WriteLine(carNumber);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
