using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Strings_and_RegEx
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] text = Console.ReadLine().ToCharArray();
            var result = text.Reverse().ToArray();
            Console.WriteLine(result);
        }
    }
}
