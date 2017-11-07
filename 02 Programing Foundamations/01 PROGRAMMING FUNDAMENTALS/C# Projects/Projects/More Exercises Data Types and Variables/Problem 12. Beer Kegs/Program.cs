using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_12.Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            int numberOfkegs = int.Parse(Console.ReadLine());
            string maxModelVolume = null;
            double maxVolume = 0;
            for (int i = 1; i <= numberOfkegs; i++)
            {
                string currentModel = Console.ReadLine();
                float radius = float.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                double Volume = Math.PI * Math.Pow(radius, 2) * height;
                if (Volume > maxVolume)
                {
                    maxVolume = Volume;
                    maxModelVolume = currentModel;
                }
                            }
            Console.WriteLine(maxModelVolume);
        }
    }
}
