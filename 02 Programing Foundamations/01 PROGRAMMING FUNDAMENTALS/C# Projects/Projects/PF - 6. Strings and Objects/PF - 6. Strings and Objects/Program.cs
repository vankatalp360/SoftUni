using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___6.Strings_and_Objects
{
    class Program
    {
        static void Main(string[] args)
        {
            string FirstString = "Hello";
            string SecondString = "World";
            object Combination = FirstString + " " + SecondString;
            Console.WriteLine(Combination);
        }
    }
}
