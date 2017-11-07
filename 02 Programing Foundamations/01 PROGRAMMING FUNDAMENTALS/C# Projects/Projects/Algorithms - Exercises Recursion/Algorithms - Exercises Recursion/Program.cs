using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms___Exercises_Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            ReverseArray(arr,0);
            Console.WriteLine(string. Join(" ", arr));
        }

        private static void ReverseArray(int[] arr, int index)
        {
            if (index ==arr.Length/2)
            {
                return;
            }
            Swap(arr, index, arr.Length-index-1);
            ReverseArray(arr, index + 1);
        }

        private static void Swap(int[] arr, int index1, int index2)
        {
            int oldValue = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = oldValue;
        }
    }
}
