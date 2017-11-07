using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3.Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            short n = short.Parse(Console.ReadLine());

            short capacity = 255;
            short capacityLeft = capacity;

            for (short i = 0; i < n; i++)
            {
                short litersToPour = short.Parse(Console.ReadLine());

                if (capacityLeft - litersToPour >= 0)
                {
                    capacityLeft -= litersToPour;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }
            short filled = (short)(capacity - capacityLeft) ;
            Console.WriteLine(filled);
        }
    }
}
