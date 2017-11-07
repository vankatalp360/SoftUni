using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___5.Sort_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> InputNumbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToList();
            InputNumbers.Sort();
            Console.WriteLine(string.Join(" <= ", InputNumbers));
        }
    }
}
