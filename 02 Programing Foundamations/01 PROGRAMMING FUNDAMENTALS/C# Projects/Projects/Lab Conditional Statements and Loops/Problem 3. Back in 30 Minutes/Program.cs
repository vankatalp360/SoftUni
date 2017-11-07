using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3.Back_in_30_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int Hours = int.Parse(Console.ReadLine());
            int Minutes = int.Parse(Console.ReadLine());
            if (Hours >= 0 && Hours <= 23 && Minutes >= 0 && Minutes <= 59)
            {
                Minutes = Minutes + 30;
                if (Minutes>=60) { Minutes= Minutes - 60; Hours = Hours + 1; }
                if (Hours == 24) Hours = 0;
                Console.WriteLine($"{Hours}:{Minutes:d2}");
            }
        }
    }
}
