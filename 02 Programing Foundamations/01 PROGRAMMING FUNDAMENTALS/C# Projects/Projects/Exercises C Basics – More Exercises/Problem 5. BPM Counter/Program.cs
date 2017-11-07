using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_5.BPM_Counter
{
    class Program
    {
        static void Main(string[] args)
        {
            int BPM = int.Parse(Console.ReadLine());
            int beats = int.Parse(Console.ReadLine());
            double bars = Math.Round(beats / 4.0d,1);
            int minutes = beats / BPM ;
            decimal seconds = Math.Floor((decimal)beats / BPM * 60-minutes*60);
            Console.WriteLine($"{bars} bars - {minutes}m {seconds}s");
        }
    }
}
