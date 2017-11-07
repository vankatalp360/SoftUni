using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises_C_Conditional_Statements
{
    class Program
    {
        static void Main(string[] args)
        {
            string Profession = Console.ReadLine();
            string Drink = null;
            switch (Profession)
            {
                case "Athlete":
                    Drink = "Water";
                    break;
                case "Businessman":
                case "Businesswoman":
                    Drink = "Coffee";
                    break;
                case "SoftUni Student":
                    Drink = "Beer";
                    break;
                default:
                    Drink = "Tea";
                    break;
            }
            Console.WriteLine(Drink);
        }
    }
}
