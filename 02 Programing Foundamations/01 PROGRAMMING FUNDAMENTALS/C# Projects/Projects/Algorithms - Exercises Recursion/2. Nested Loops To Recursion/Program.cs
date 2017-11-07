using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Nested_Loops_To_Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            Iteration(0, arr, n);
        }

        private static void Iteration(int index, int[] arr, int n)
        {
            if (index >= arr.Length)
            {
                Console.WriteLine(string.Join(" ", arr));
                return;
            }
            for (int i = 0; i < n; i++)
            {
                arr[index] = i + 1;
                Iteration(index + 1, arr, n);
            }
        }
    }
}
