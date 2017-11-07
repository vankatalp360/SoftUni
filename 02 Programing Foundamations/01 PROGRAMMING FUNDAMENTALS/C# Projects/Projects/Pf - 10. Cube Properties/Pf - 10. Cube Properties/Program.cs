using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pf___10.Cube_Properties
{
    class Program
    {
        static void Main(string[] args)
        {
            double Side = double.Parse(Console.ReadLine());
            string Command = Console.ReadLine();
            Console.WriteLine($"{CalculateTheResult(Side, Command):F2}");
        }
        private static double CalculateTheResult(double Side, string Command)
        {
            double Result=0;
            switch (Command)
            {
                case "face":
                    Result = CalculateCubeFaceDiagonal(Side);
                    break;
                case "area":
                    Result = CalculateCubeArea(Side);
                    break;
                case "space":
                    Result = CalculateCubeSpaceDiagonal(Side);
                    break;
                case "volume":
                    Result = CalculateCubeVolume(Side);
                    break;
                default:
                    Console.WriteLine("Incorect input data!!!");
                    break;
            }
            return Result;
        }
        private static double CalculateCubeVolume(double Side)
        {
            return Math.Pow(Side, 3);
        }
        private static double CalculateCubeArea(double Side)
        {
            return 6 * Math.Pow(Side, 2);
        }
        private static double CalculateCubeFaceDiagonal(double Side)
        {
            return Math.Sqrt(2 * Math.Pow(Side, 2));
        }
        private static double CalculateCubeSpaceDiagonal(double Side)
        {
            return Math.Sqrt(3 * Math.Pow(Side, 2));
        }
    }
}
