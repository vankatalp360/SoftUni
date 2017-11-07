using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___Exercises_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int Number = int.Parse(Console.ReadLine());
            List<string> WeeklyDays = new List<string>{  "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            if (Number <= 0 || Number > 7) Console.WriteLine("Invalid Day!");
            else Console.WriteLine(WeeklyDays[Number-1]);
        }
    }
}
