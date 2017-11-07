using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___16.Comparing_Floats
{
    class Program
    {
        static void Main(string[] args)
        {
            double FirstNumber = double.Parse(Console.ReadLine());
            double SecondNumber = double.Parse(Console.ReadLine());
            double Result = Math.Abs( FirstNumber - SecondNumber);
            double epc= 0.000001;
            Console.WriteLine(Result<= epc);
        }
    }
}
