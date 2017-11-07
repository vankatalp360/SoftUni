using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Distance_Between_Points
{
    class Program
    {
        static void Main(string[] args)
        {
            Point p1 = ReadPoint();
            Point p2 = ReadPoint();
            double distance = CalculateDistanceBetweenTwoPoints(p1, p2);
            Console.WriteLine($"{distance:f3}");
        }
        private static double CalculateDistanceBetweenTwoPoints(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        private static Point ReadPoint()
        {
            string[] numbers = Console.ReadLine().Split().ToArray();
            Point p = new Point { X = int.Parse(numbers[0]), Y = int.Parse(numbers[1]) };
            return p;
        }
    }
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
