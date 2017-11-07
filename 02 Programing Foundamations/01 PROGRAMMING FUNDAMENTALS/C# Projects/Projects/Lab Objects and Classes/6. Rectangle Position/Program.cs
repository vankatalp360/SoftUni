using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Rectangle_Position
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangular firstRec = ReadRectangular();
            Rectangular secondRec = ReadRectangular();
            if (IsInside(firstRec, secondRec) == true)
                Console.WriteLine("Inside");
            else
                Console.WriteLine("Not inside");
        }

        private static Rectangular ReadRectangular()
        {
            Rectangular current = new Rectangular();
            int[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            current.Left = parameters[0];
            current.Top = parameters[1];
            current.Width = parameters[2];
            current.Height = parameters[3];
            return current;
        }

        private static bool IsInside(Rectangular r1, Rectangular r2)
        {
            bool result = false;
            if (r1.Left >= r2.Left)
            {
                if (r1.Left + r1.Width <= r2.Left + r2.Width)
                {
                    if (r1.Top <= r2.Top)
                    {
                        if (r1.Top - r1.Height >= r2.Top - r2.Height)
                            result = true;
                    }
                }
            }
            return result;
        }
    }

    class Rectangular
    {
        public int Top { get; set; }
        public int Left { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
