using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Geometry_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();
            switch (figure)
            {
                case "triangle":
                    Console.WriteLine($"{CalculateTriangleArea():F2}");
                    break;
                case "square":
                    Console.WriteLine($"{CalculateSquareArea():F2}");
                    break;
                case "rectangle":
                    Console.WriteLine($"{CalculateRectangleArea():F2}");
                    break;
                case "circle":
                    Console.WriteLine($"{CalculateCircleArea():F2}");
                    break;
                default:
                    Console.WriteLine("Incorrect figure name!");
                    break;
            }
        }
        private static double CalculateTriangleArea()
        {
            double side = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            return side * height / 2;
        }
        private static double CalculateSquareArea()
        {
            double side = double.Parse(Console.ReadLine());
            return side * side;
        }
        private static double CalculateRectangleArea()
        {
            double side = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            return side * height;
        }
        private static double CalculateCircleArea()
        {
            double radius = double.Parse(Console.ReadLine());
            
            return Math.PI* radius* radius;
        }
    }
}
