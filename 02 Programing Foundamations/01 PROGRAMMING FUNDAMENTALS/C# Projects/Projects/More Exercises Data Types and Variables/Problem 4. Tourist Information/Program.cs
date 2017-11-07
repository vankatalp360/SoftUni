using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4.Tourist_Information
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            string unitType = Console.ReadLine();
            double value = double.Parse(Console.ReadLine());
            double converterValue;
            string converterUnit;
            switch (unitType)
            {
                case "miles":
                    converterValue = 1.6;
                    converterUnit = "kilometers";
                    Console.WriteLine($"{value} {unitType} = {value*converterValue:f2} {converterUnit}");
                    break;
                case "inches":
                    converterValue = 2.54;
                    converterUnit = "centimeters";
                    Console.WriteLine($"{value} {unitType} = {value*converterValue:f2} {converterUnit}");
                    break;
                case "feet":
                    converterValue = 30;
                    converterUnit = "centimeters";
                    Console.WriteLine($"{value} {unitType} = {value*converterValue:f2} {converterUnit}");
                    break;
                case "yards":
                    converterValue = 0.91;
                    converterUnit = "meters";
                    Console.WriteLine($"{value} {unitType} = {value*converterValue:f2} {converterUnit}");
                    break;
                case "gallons":
                    converterValue = 3.8;
                    converterUnit = "liters";
                    Console.WriteLine($"{value} {unitType} = {value*converterValue:f2} {converterUnit}");
                    break;
                default:
                    Console.WriteLine("Incorect input unit or value!");
                    break;
            }
        }
    }
}
