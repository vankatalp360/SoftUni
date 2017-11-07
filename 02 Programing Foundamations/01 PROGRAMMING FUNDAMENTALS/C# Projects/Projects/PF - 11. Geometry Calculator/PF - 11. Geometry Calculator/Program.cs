using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___11.Geometry_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string FigureType = Console.ReadLine();
            double FigureArea = CalculateFigureArea(FigureType);
            Console.WriteLine($"{FigureArea:F2}");
        }
        private static double CalculateFigureArea(string FigureType)
        {
            double Area = 0;
            switch (FigureType)
            {
                case "triangle":
                    Area = CalculateTriangleArea();
                    break;
                case "square":
                    Area = CalculateSquareArea();
                    break;
                case "rectangle":
                    Area = CalculateRectangleArea();
                    break;
                case "circle":
                    Area = CalculateCircleArea();
                    break;
                default:
                    Console.WriteLine("Incorect data inpute!");
                    break;
            }
            return Area;
        }
        private static double CalculateTriangleArea()
        {
            double TriangleSide = double.Parse(Console.ReadLine());
            double TriangleHeight = double.Parse(Console.ReadLine());
            return TriangleHeight * TriangleSide / 2;
        }
        private static double CalculateSquareArea()
        {
            double SquareSide = double.Parse(Console.ReadLine());
            return Math.Pow(SquareSide, 2);
        }
        private static double CalculateRectangleArea()
        {
            double RectangularSide = double.Parse(Console.ReadLine());
            double RectangularHeight = double.Parse(Console.ReadLine());
            return RectangularHeight * RectangularSide;
        }
        private static double CalculateCircleArea()
        {
            double CircleRadius = double.Parse(Console.ReadLine());
            return Math.PI*Math.Pow(CircleRadius,2);
        }
    }
}
