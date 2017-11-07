using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___5.Calculate_Triangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            double TriangleBase = double.Parse(Console.ReadLine());
            double TriangleHeight = double.Parse(Console.ReadLine());
            double Area = CalculateArea(TriangleBase, TriangleHeight);
            Console.WriteLine(Area);
        }
        static double CalculateArea(double TheBase, double TheHeight)
        {
            double Area = TheBase * TheHeight/2;
            return Area;
        }
    }
}
