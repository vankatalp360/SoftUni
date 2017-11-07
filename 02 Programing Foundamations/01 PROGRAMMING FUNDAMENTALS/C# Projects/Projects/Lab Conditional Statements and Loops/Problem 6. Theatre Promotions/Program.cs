using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_6.Theatre_Promotions
{
    class Program
    {
        static void Main(string[] args)
        {
            string Day = Console.ReadLine();
            int Age = int.Parse(Console.ReadLine());
            if (Age < 0 || Age > 122) Console.WriteLine("Error!");
            else
            {
                int price = 0;
                if (Age<=18)
                {
                    if (Day == "Weekday") price = 12;
                    else if (Day == "Weekend") price = 15;
                    else if (Day == "Holiday") price = 5;
                }
                else if (Age<=64)
                {
                    if (Day == "Weekday") price = 18;
                    else if (Day == "Weekend") price = 20;
                    else if (Day == "Holiday") price = 12;
                }
                else
                {
                    if (Day == "Weekday") price = 12;
                    else if (Day == "Weekend") price = 15;
                    else if (Day == "Holiday") price = 10;
                }
                Console.WriteLine($"{price}$");
            }
        }
    }
}
