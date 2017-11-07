using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___4.Largest_3_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] Letters = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            //Letters = Letters.OrderByDescending(x => x).Take(3).ToArray();
            //Console.WriteLine(string.Join(" ",Letters));
            //All above could be made in a single row

            Console.WriteLine(string.Join(" ", Console.ReadLine().Split(' ').Select(int.Parse).OrderByDescending(x => x).Take(3).ToArray()));
        }
    }
}
