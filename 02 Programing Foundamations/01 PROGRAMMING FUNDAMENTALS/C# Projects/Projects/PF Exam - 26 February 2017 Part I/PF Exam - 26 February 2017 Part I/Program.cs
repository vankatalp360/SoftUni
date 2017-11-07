using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_Exam___26_February_2017_Part_I
{
    class Program
    {
        static void Main(string[] args)
        {
            //You will be given N – an integer indicating the wing flaps, a contestant has chosen to do.
            int wingFlaps = int.Parse(Console.ReadLine());
            //After that, you will receive M – a floating-point number indicating the distance, in meters, the hornet travels for 1000 wing flaps.
            double distanceForATousantFlaps = double.Parse(Console.ReadLine());
            //Then you will receive P – an integer indicating the endurance of the contestant, or how many wing flaps he can make, before he stops to take a break and rest.
            int endurance = int.Parse(Console.ReadLine());
            //A hornet rests for 5 seconds.
            //You can assume that a hornet makes 100 wing flaps per second.
            const int restTime = 5;
            double totalDistance = wingFlaps * distanceForATousantFlaps / 1000;
            int totalRests = wingFlaps / endurance;
            int totalTime = totalRests * restTime + wingFlaps / 100;
            Console.WriteLine($"{totalDistance:f2} m.");
            Console.WriteLine($"{totalTime} s.");
        }
    }
}
