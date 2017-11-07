using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___6.Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double Number = double.Parse(Console.ReadLine());
            int Power = int.Parse(Console.ReadLine());
            double NumberToPower = RaiseToPower(Number, Power);
            Console.WriteLine(NumberToPower);
        }
        static double RaiseToPower(double number, int power)
        {
            double Result = Math.Pow(number,power);
            return Result;
        }
    }
}
