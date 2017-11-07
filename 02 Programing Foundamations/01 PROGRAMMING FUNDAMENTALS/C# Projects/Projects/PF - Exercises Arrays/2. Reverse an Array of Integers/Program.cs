using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Reverse_an_Array_of_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int NumberOfIntegers = int.Parse(Console.ReadLine());
            List<int> Numbers = new List<int>();
            for (int i = 0; i <NumberOfIntegers; i++)
            {
                int number = int.Parse(Console.ReadLine());
                Numbers.Add(number);
            }
            Numbers.Reverse();
            Console.WriteLine(string.Join(" ", Numbers));
        }
    }
}
