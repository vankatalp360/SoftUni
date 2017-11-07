using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___Lab_Data_Types_and_Variables
{
    class Program
    {
        static void Main(string[] args)
        {
            uint Centuries = uint.Parse(Console.ReadLine());
            uint Years = Centuries * 100;
            uint Days = (uint)(Years * 365.2422);
            uint Hours = Days * 24;
            long Minuters = Hours * 60;
            Console.WriteLine($"{Centuries} centuries = {Years} years = {Days} days = {Hours} hours = {Minuters} minutes");
        }
    }
}
