using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP_V___Taking_a_Sample_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int wingFlaps = int.Parse(Console.ReadLine());
            double distancePerTousanFlaps = double.Parse(Console.ReadLine());
            int restDuration = int.Parse(Console.ReadLine());
            const int frequency = 100;
            const int breakDuration = 5;

            double totalDistance = distancePerTousanFlaps / 1000 * wingFlaps;

            int breaksCount = wingFlaps / restDuration;
            int breaksTotalTime = breaksCount * breakDuration;
            int totalTime = wingFlaps / frequency + breaksTotalTime;

            Console.WriteLine($"{totalDistance:F2} m.");
            Console.WriteLine($"{totalTime} s.");
        }
    }
}
