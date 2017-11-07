using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___Exercises_C_Intro_and_Basic_Syntax
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[4];
            for (int i = 0; i < 4; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }
           for(int i =0; i <numbers.Length;i++)
            {
                Console.Write($"{numbers[i]:D4}"); 
                if (i<numbers.Length-1) Console.Write($" "); else Console.WriteLine();
            }
        }
    }
}
