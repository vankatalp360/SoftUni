using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Recursive_Drawing
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            DrawFigure(rows);
        }

        private static void DrawFigure(int rows)
        {
            if (rows <= 0)
                return;
            Console.WriteLine(new string('*',rows));
            DrawFigure(rows - 1);
            Console.WriteLine(new string('#', rows));
        }
    }
}
