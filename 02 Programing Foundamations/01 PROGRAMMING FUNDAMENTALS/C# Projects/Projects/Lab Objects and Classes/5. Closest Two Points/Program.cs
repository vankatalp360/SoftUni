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
            int pointsNumber = int.Parse(Console.ReadLine());
            List<Point> points = new List<Point>();
            for (int i = 1; i <= pointsNumber; i++)
            {
                points.Add(ReadPoint());
            }
            double maxDistance = double.MaxValue;
            Point firstPoint = null;
            Point secondPoint = null;
            DefineTheClosestPoints(points, ref maxDistance, ref firstPoint, ref secondPoint);
            PrintResult(maxDistance, firstPoint, secondPoint);
        }

        private static void PrintResult(double maxDistance, Point firstPoint, Point secondPoint)
        {
            Console.WriteLine($"{maxDistance:f3}");
            Console.WriteLine($"({firstPoint.X}, {firstPoint.Y})");
            Console.WriteLine($"({secondPoint.X}, {secondPoint.Y})");
        }

        private static void DefineTheClosestPoints(List<Point> points, ref double maxDistance, ref Point firstPoint, ref Point secondPoint)
        {
            foreach (var first in points)
            {
                foreach (var second in points)
                {
                    if (first != second)
                    {
                        double distance = CalculateDistanceBetweenTwoPoints(first, second);
                        if (maxDistance > distance)
                        {
                            maxDistance = distance;
                            firstPoint = first;
                            secondPoint = second;
                        }
                    }
                }
            }
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
