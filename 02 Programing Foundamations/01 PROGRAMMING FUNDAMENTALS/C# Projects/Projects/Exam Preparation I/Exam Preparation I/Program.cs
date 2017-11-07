using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Preparation_I
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime leftTime = DateTime.ParseExact(Console.ReadLine(), "HH:mm:ss", CultureInfo.InvariantCulture);
            int numberOfSteps = int.Parse(Console.ReadLine()) % 86400;
            int timeForStep = int.Parse(Console.ReadLine()) % 86400;
            long totalTime = (long)numberOfSteps * timeForStep;
            DateTime arriveTime = leftTime.AddSeconds(totalTime);
            string result = arriveTime.ToString("HH:mm:ss");
            Console.WriteLine($"Time Arrival: {result}");
        }
    }
}
