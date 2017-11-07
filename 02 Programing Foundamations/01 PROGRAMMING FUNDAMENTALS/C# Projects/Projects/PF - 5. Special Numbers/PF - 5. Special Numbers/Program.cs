using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___5.Special_Numbers
{
    class Program
    {

        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            for (int i = 1; i <= N; i++)
            {
                int SumOfDig = 0;
                int M = i;

                while (M != 0)
                {
                    SumOfDig += M % 10;
                    M = M / 10;
                }
                Console.WriteLine("{0} -> {1}", i, (SumOfDig == 5 || SumOfDig == 7 || SumOfDig == 11));
            }
        }
    }
}
