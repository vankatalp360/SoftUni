using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___9.Longer_Line
{
    class Program
    {
        static void Main(string[] args)
        {
            double X1 = double.Parse(Console.ReadLine());
            double Y1 = double.Parse(Console.ReadLine());
            double X2 = double.Parse(Console.ReadLine());
            double Y2 = double.Parse(Console.ReadLine());
            double X3 = double.Parse(Console.ReadLine());
            double Y3 = double.Parse(Console.ReadLine());
            double X4 = double.Parse(Console.ReadLine());
            double Y4 = double.Parse(Console.ReadLine());
            double FirstDistance = CalculateDistanceBetweenPoints(X1, Y1, X2, Y2);
            double SecondDistance = CalculateDistanceBetweenPoints(X3, Y3, X4, Y4);
            if (FirstDistance >= SecondDistance)
            {
                double FirstPair = CalculateDistanceBetweenPoints(X1, Y1, 0, 0);
                double SecondPair = CalculateDistanceBetweenPoints(X2, Y2, 0, 0);
                if (FirstPair <= SecondPair) Console.WriteLine($"({X1}, {Y1})({X2}, {Y2})");
                else Console.WriteLine($"({X2}, {Y2})({X1}, {Y1})");
            }
            else
            {
                double FirstPair = CalculateDistanceBetweenPoints(X3, Y3, 0, 0);
                double SecondPair = CalculateDistanceBetweenPoints(X4, Y4, 0, 0);
                if (FirstPair <= SecondPair) Console.WriteLine($"({X3}, {Y3})({X4}, {Y4})");
                else Console.WriteLine($"({X4}, {Y4})({X3}, {Y3})");
            }
        }
        private static double CalculateDistanceBetweenPoints(double X1, double Y1, double X2, double Y2)
        {
            double X = Math.Abs(X1 - X2);
            double Y = Math.Abs(Y1 - Y2);
            double Distance = Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
            return Distance;
        }
    }
}
