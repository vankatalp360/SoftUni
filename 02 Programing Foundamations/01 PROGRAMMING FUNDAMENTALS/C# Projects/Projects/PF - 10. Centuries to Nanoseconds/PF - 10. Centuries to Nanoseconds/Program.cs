using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___10.Centuries_to_Nanoseconds
{
    class Program
    {
        static void Main(string[] args)
        {
            int Centuries = int.Parse(Console.ReadLine());
            int Years = Centuries * 100;
            double Days = Years * 365.2422;
            int Hours = (int)Days * 24;
            int Minutes = Hours * 60;
            long Seconds = (long) Minutes * 60;
            long Milliseconds =Seconds * 1000;
            long Microseconds = Milliseconds * 1000;
            BigInteger Nanoseconds = (BigInteger)Microseconds * 1000;
            Console.WriteLine("{0} centuries = {1} years = {2} days = {3} hours = {4} minutes = {5} seconds = {6} milliseconds = {7} microseconds = {8} nanoseconds", Centuries, Years, (int)Days, Hours, Minutes, Seconds, Milliseconds, Microseconds, Nanoseconds);
        }
    }
}
