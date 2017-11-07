using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_10.Sum_of_Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int total = 0;
            for (int i = 1; i <= n; i++)
            {
                total = total + char.Parse(Console.ReadLine());
            }
            Console.WriteLine($"The sum equals: {total}");
        }
    }
}
