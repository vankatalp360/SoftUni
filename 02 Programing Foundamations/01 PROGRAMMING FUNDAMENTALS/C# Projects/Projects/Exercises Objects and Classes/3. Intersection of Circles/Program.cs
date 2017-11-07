using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Intersection_of_Circles
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle firstCircle = ReadCircle();
            Circle secondCircle = ReadCircle();
            if (Intersect(firstCircle, secondCircle)) Console.WriteLine("Yes");
            else Console.WriteLine("No");
        }
        private static bool Intersect(Circle c1, Circle c2)
        {
            double distance = CalculateDistanceBetweenCenters(c1.Center, c2.Center);
            if (distance <= c1.Radius + c2.Radius) return true;
            else return false;
        }
        private static double CalculateDistanceBetweenCenters(Point M, Point N)
        {
            double result = Math.Sqrt(Math.Pow(M.X - N.X, 2) + Math.Pow(M.Y - N.Y, 2));
            return result;
        }
        private static Circle ReadCircle()
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Point center = new Point();
            center.X = input[0];
            center.Y = input[1];
            Circle currentCircle = new Circle();
            currentCircle.Radius = input[2];
            currentCircle.Center = center;
            return currentCircle;
        }
    }
    class Circle
    {
        public Point Center { get; set; }
        public int Radius { get; set; }
    }
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
