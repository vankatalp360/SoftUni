using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Combinations_with_Repetition
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int[] arr = new int[k];
            Combination(arr, 0, 0,n);
        }

        private static void Combination(int[] arr, int index, int startIndex,int maxNumber)
        {
            if (index>=arr.Length)
            {
                PrintArray(arr);
                return;
            }
            
            for(int i = startIndex; i < maxNumber; i++)
            {
                arr[index] = i+1;
                Combination(arr, index + 1, i,maxNumber);
            }
        }

        private static void PrintArray (int [] arr)
        {
            Console.WriteLine(string.Join(" ",arr));
        }
    }
}
