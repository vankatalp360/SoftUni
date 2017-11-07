using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___4.Draw_a_Filled_Square
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            PrintSquare(n);
        }
        static void PrintSquare(int n)
        {
            PrintHeaderOrFooter(n);
            PrintTheBody(n);
            PrintHeaderOrFooter(n);
        }
        static void PrintHeaderOrFooter(int n)
        {
            Console.WriteLine(new string('-', 2 * n));
        }
        static void PrintTheBody(int n)
        {
            for (int i = 1; i <= n - 2; i++)
                PrintMiddleRow(n);
        }
        static void PrintMiddleRow(int n)
        {
            Console.Write("-");
            for (int i = 1; i < n; i++)
                Console.Write("\\/");
            Console.WriteLine("-");
        }
    }
}
