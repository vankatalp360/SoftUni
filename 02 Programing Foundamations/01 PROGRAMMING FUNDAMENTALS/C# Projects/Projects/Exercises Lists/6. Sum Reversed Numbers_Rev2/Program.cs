using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Sum_Reversed_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
          Console.WriteLine(Console.ReadLine().Split().Select(e => new String(e.Reverse().ToArray())).Sum(e => int.Parse(e)));
        }
    }
}
