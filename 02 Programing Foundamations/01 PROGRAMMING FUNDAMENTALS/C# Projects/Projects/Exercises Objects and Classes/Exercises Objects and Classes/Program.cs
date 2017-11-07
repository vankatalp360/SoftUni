using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises_Objects_and_Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, string>> holidays = new Dictionary<string, Dictionary<string, string>>()
            {
                {"New Year Eve", new Dictionary<string, string>(){{ "1", "1" }}},
                 {"Liberation Day", new Dictionary<string, string>(){{ "2", "3" } }},
                 {"Worker’s day", new Dictionary<string, string>(){{ "1", "5" } }},
                 {"Saint George’s Day", new Dictionary<string, string>(){{ "6", "5" } }},
                 {"Saints Cyril and Methodius Day", new Dictionary<string, string>(){{ "24", "5" } }},
                  {"Unification Day", new Dictionary<string, string>(){{ "6", "9" } }},
                  {"Independence Day", new Dictionary<string, string>(){{ "22", "9" } }},
                  {"National Awakening Day", new Dictionary<string, string>(){{ "1", "11" } }},
                  {"Christmas", new Dictionary<string, string>(){{ "24", "12" },{ "25", "12" },{ "26", "12" } }}
            };
            DateTime firstDate = ReadDate();
            DateTime secondDate = ReadDate();
            int counter = 0;
            for (DateTime i = ( firstDate<=secondDate? firstDate:secondDate ); i <= (firstDate > secondDate ? firstDate : secondDate); i = i.AddDays(1))
            {
                if (CheckIfTheDayIsNotHoliday(i, holidays)) counter++;
            }
            Console.WriteLine(counter);
        }
        private static DateTime ReadDate()
        {
            DateTime newDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            return newDate;
        }
        private static bool CheckIfTheDayIsNotHoliday(DateTime currentDate, Dictionary<string, Dictionary<string, string>> holidays)
        {
            if (currentDate.DayOfWeek.ToString() == "Saturday" || currentDate.DayOfWeek.ToString() == "Sunday") return false;
            string day = currentDate.Day.ToString();
            string month = currentDate.Month.ToString();
            bool result = Holidays(day, month, holidays);
            if (result) return false;
            return true;
        }
        private static bool Holidays(string day, string numberOfMonth, Dictionary<string, Dictionary<string, string>> holidays)
        {

            bool result = false;
            foreach (var pair in holidays)
            {
                if (!result)
                {
                    if (pair.Value.ContainsKey(day))
                    {
                        if (pair.Value[day] == numberOfMonth)
                        {
                            result = true;
                            break;
                        }
                    }
                }
                else break;
            }
            return result;
        }
    }
}
