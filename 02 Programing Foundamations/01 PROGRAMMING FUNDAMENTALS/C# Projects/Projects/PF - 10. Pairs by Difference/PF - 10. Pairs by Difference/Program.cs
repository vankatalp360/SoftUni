using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___10.Pairs_by_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] Array = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int Number = int.Parse(Console.ReadLine());
            int result = 0;
            for (int i = 0; i<Array.Length-1;i++)
            {
               for (int j =i +1; j<Array.Length;j++)
                {
                    if (Math.Abs( Array[i] - Array[j]) == Number) result++;
                }
            }
            Console.WriteLine(result);
        }
    }
}
