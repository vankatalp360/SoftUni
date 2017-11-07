using System;
using System.Globalization; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___9.Holidays_Between_Two_Dates
{
    class Program
    {
        static void Main()
        {
            var formats = new string[4] { "dd.MM.yyyy", "d.MM.yyyy", "dd.M.yyyy", "d.M.yyyy" }.ToArray();
            var startDate = DateTime.ParseExact(Console.ReadLine(),
                formats, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal);
            var endDate = DateTime.ParseExact(Console.ReadLine(),
                formats, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal);
            var holidaysCount = 0;
            for (var date = startDate; date <= endDate; date=date.AddDays(1))
                if (date.DayOfWeek == DayOfWeek.Saturday ||
                    date.DayOfWeek == DayOfWeek.Sunday) holidaysCount++;
            Console.WriteLine(holidaysCount);
        }
    }
}
