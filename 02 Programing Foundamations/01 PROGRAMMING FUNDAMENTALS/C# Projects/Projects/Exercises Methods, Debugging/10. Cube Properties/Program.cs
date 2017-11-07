using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Cube_Properties
{
    class Program
    {
        static void Main(string[] args)
        {
            double side = double.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            DefineAndCalculateResult(side, command);
        }

        private static void DefineAndCalculateResult(double side, string command)
        {
            switch (command)
            {
                case "face":
                    Console.WriteLine($"{CalculateCubeFace(side):F2}");
                    break;
                case "space":
                    Console.WriteLine($"{CalculateCubeSpace(side):F2}");
                    break;
                case "volume":
                    Console.WriteLine($"{CalculateCubeVolume(side):F2}");
                    break;
                case "area":
                    Console.WriteLine($"{CalculateCubeArea(side):F2}");
                    break;
                default:
                    Console.WriteLine("Incorrect command!");
                    break;
            }
        }

        private static double CalculateCubeArea(double side)
        {
            return side * side * 6;
        }
        private static double CalculateCubeVolume(double side)
        {
            return Math.Pow(side,3);
        }
        private static double CalculateCubeSpace(double side)
        {
            return Math.Sqrt(3*side*side);
        }
        private static double CalculateCubeFace ( double side)
        {
            return Math.Sqrt(2*Math.Pow(side,2));
        }
    }
}
