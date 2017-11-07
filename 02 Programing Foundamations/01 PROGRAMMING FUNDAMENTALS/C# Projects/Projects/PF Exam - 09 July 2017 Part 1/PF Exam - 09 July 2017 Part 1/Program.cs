using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF_Exam___09_July_2017_Part_1
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            long m = long.Parse(Console.ReadLine());
            long y = long.Parse(Console.ReadLine());
            long counter = 0;
            double original = n;
            while (true)
            {
                if (n < m) break;
                if ((double)n == original / 2)
                {
                   if (y!=0) n = n / y;
                }
                if (n < m) break;
                n = n - m;
                counter++;
            }
            Console.WriteLine(n);
            Console.WriteLine(counter);
        }
    }
}
