using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_10.Triangle_of_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int i=1; i<=number;i++)
            {
                for (int j =1; j<=i;j++)
                {
                   if (j!=i) Console.Write(i + " ");
                    else Console.WriteLine(i);
                }
            }
        }
    }
}
