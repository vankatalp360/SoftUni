using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___3.Printing_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            PrintTriangel(N);
        }
        static void PrintTriangel(int N)
        {
            for (int i = 1; i <= N; i++)
            {
                PrintLine(1, i);
            }
            for (int i = N - 1; i >= 1; i--)
            {
                PrintLine(1, i);
            }
        }
        static void PrintLine(int start, int end)
        {
            for (int i =start;i<=end;i++)
            {
                Console.Write(i);
                if (i != end) Console.Write(' ');
            }
            Console.WriteLine();
        }
    }
}
