using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___1.Hello__Name_
{
    class Program
    {
        static void Main(string[] args)
        {
            string YourNameIs=Console.ReadLine();
            PringGrating(YourNameIs);
        }
        static void PringGrating(string Name)
        {
            Console.WriteLine($"Hello, {Name}!");
        }
    }
}
