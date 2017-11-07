using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises_Methods__Debugging
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = ReadNames();
            PringGreatingName(name);
        }

        private static void PringGreatingName(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }

        private static string ReadNames()
        {
            string name = Console.ReadLine();
            return name;
        }
    }
}
