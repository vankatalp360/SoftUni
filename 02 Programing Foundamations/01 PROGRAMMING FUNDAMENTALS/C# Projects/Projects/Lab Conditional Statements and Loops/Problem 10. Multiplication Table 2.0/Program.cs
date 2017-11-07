using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_10.Multiplication_Table_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int start = int.Parse(Console.ReadLine());
            if (start<=10)
            {
                for (int i = start; i <= 10; i++)
                {
                    Console.WriteLine($"{number} X {i} = {number * i}");
                }
            }
            else Console.WriteLine($"{number} X {start} = {number * start}");
        }
    }
}
