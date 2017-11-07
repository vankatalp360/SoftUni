using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___2.Circle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            double Radious = double.Parse(Console.ReadLine());
            double Area = Math.PI * Math.Pow(Radious, 2);
            Console.WriteLine("{0:F12}", Area);
        }
    }
}
