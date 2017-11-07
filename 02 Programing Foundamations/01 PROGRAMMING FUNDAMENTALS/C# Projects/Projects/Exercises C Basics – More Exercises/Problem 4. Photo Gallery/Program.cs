using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4.Photo_Gallery
{
    class Program
    {
        static void Main(string[] args)
        {
            int Name = int.Parse(Console.ReadLine());
            int Day = int.Parse(Console.ReadLine());
            int Month = int.Parse(Console.ReadLine());
            int Year = int.Parse(Console.ReadLine());
            int Hours = int.Parse(Console.ReadLine());
            int Minutes = int.Parse(Console.ReadLine());
            uint Size = uint.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            DateTime DateTaken = new DateTime(Year, Month, Day, Hours, Minutes, 0);
            Console.WriteLine($"Name: DSC_{Name:d4}.jpg");
            Console.WriteLine($"Date Taken: {DateTaken.ToString("dd'/'MM'/'yyyy HH:mm")}");
            decimal Resize = 0;
            string impresion = null;
            if (Size / 1000000 >= 1)
            { Resize = Math.Round(Size / (decimal)1000000,1); impresion = "MB"; }
            else if (Size / 1000 >= 1)
            { Resize = Math.Round(Size / (decimal)1000,1); impresion = "KB"; }
            else { Resize = Size; impresion = "B"; }
            Console.WriteLine($"Size: {Resize}{impresion}");
            string orientation = null;
            if (width > height) orientation="landscape";
            else if (width == height) orientation = "square";
            else orientation = "portrait";
            Console.WriteLine($"Resolution: {width}x{height} ({orientation})");
        }
    }
}
