using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_10._5_Different_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            if (second - first < 5) Console.WriteLine("No");
            else
            {
                for (int i =first;i<=second-4;i++)
                {
                    for (int j = i+1; j <= second - 3; j++)
                    {
                        for (int k = j+1; k <= second - 2; k++)
                        {
                            for (int m= k+1; m <= second - 1; m++)
                            {
                                for (int n = m+1; n <= second ; n++)
                                {
                                    Console.WriteLine(i+" "+j+ " " +k+ " " +m+ " " +n);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
