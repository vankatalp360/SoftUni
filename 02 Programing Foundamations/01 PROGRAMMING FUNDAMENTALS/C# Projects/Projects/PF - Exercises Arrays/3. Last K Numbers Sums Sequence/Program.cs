using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Last_K_Numbers_Sums_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            List<long> Sequence = new List<long>();
            Sequence.Add(1);
           
            for (int i = 1; i < n; i++)
            {
                int start = i - k;
                if (start < 0) start = 0;
                long sum = 0;
                for (int j = start; j <= i - 1; j++)
                {
                   sum=sum+ Sequence.ElementAt(j);
                }
                Sequence.Add(sum);
            }
            Console.WriteLine(string.Join(" ",Sequence));
        }
    }
}
