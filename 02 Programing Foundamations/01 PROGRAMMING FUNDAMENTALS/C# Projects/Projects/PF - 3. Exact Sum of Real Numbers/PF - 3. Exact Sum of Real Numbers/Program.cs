using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___3.Exact_Sum_of_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            decimal Sum = 0;
            for (int i=1;i<=N;i++)
            {
                Sum += decimal.Parse(Console.ReadLine());
            }
            Console.WriteLine(Sum);
        }
    }
}
