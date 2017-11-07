using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smallest_multiple
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long total = 1;
            int[] deviders = new int[n];
            for (int i = 0; i < n; i++)
            {
                deviders[i] = i + 1;
            }
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (deviders[j] % deviders[i] == 0) deviders[j] = deviders[j] / deviders[i];
                }
            }
            foreach (var i in deviders)
            {
                total *= i;
            }
            Console.WriteLine(total);
        }
    }
}
