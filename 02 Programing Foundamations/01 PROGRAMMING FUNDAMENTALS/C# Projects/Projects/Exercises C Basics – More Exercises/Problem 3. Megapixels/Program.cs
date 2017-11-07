using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3.Megapixels
{
    class Program
    {
        static void Main(string[] args)
        {
            uint width = uint.Parse(Console.ReadLine());
            uint height = uint.Parse(Console.ReadLine());
            Console.WriteLine($"{width}x{height} => {Math.Round(width * height / (decimal)1000000, 1)}MP");
        }
    }
}
