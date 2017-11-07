using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Strings_and_Text_Processing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join("", Console.ReadLine().ToCharArray().Reverse().ToArray()));
        }
    }
}
