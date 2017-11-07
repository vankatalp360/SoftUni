using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises_C_Basics___More_Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            for (int i =0; i <x/2;i++)
            {
                Console.WriteLine(new string (' ',i)+"x"+new string (' ',x-2-2*i)+"x");
            }
            Console.WriteLine(new string(' ', x / 2) + "x");
            for (int i = x / 2-1; i>=0; i--)
            {
                Console.WriteLine(new string(' ', i) + "x" + new string(' ', x - 2 - 2 * i) + "x");
            }
        }
    }
}
