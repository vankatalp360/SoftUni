using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___12.Rectangle_Properties
{
    class Program
    {
        static void Main(string[] args)
        {
            double RectangularWidth = double.Parse(Console.ReadLine());
            double RectangularHeight = double.Parse(Console.ReadLine());
            double RectangularPerimeter = 2 * (RectangularWidth + RectangularHeight);
            double RectangularArea = RectangularWidth * RectangularHeight;
            double RectangularDiagonal = Math.Sqrt(Math.Pow(RectangularWidth, 2) + Math.Pow(RectangularHeight, 2));
            Console.WriteLine(RectangularPerimeter);
            Console.WriteLine(RectangularArea);
            Console.WriteLine(RectangularDiagonal);
        }
    }
}
