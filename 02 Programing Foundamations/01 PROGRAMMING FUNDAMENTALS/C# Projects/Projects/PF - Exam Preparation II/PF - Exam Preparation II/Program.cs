using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___Exam_Preparation_II
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	On the first line of input you will get the length of the marathon in days
            //•	On the second line of input you will get the number of runners that will participate
            //•	On the third line you will get the average number of laps every runner makes
            //•	On the fourth line you will get the length of the track
            //•	On the fifth line you will get the capacity of the track
            //•	On the sixth line you will get the amount of money donated per kilometer
            //Constraints
            //•	Marathon day count will be an integer in the range[0 … 365]
            //•	Runner count will be an integer in the range[0 … 2, 147, 483, 647]
            //•	Average number of laps will be an integer in the range[0 … 100]
            //•	Lap length will be an integer in the range[0 … 2, 147, 483, 647]
            //•	Track capacity will be an integer in the range[0 … 1000]
            //•	Money per kilometer will all be a floating point number

            int maratonDurationInDays = int.Parse(Console.ReadLine());
            long numberOfRunners = long.Parse(Console.ReadLine());
            ushort averageNumberOfLaps = ushort.Parse(Console.ReadLine());
            long LapLength = long.Parse(Console.ReadLine());
            int trackCapacity = int.Parse(Console.ReadLine());
            double moneyPerkm = double.Parse(Console.ReadLine());

            long taotalCapacityOfRunners = trackCapacity * maratonDurationInDays;
            if (numberOfRunners > taotalCapacityOfRunners) numberOfRunners = taotalCapacityOfRunners;
            long totalKm = numberOfRunners * averageNumberOfLaps * LapLength / 1000;
            double moneyRised = totalKm * moneyPerkm;
            Console.WriteLine($"Money raised: {moneyRised:f2}");
        }
    }
}
