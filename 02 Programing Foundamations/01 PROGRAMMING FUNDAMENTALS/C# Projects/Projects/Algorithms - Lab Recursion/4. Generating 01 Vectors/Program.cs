using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Generating_01_Vectors
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int [] arr = new int [size];
            ArrGenerator(arr, 0);
        }

        private static void ArrGenerator(int[] arr, int index)
        {
            if (index>=arr.Length)
            {
                PrintArray(arr);
                return;
            }
            for(int i =0; i <=1; i++)
            {
                arr[index] = i;
                ArrGenerator(arr, index + 1);
            }
        }

        private static void PrintArray(int[] arr)
        {
            Console.WriteLine(string.Join("",arr));
        }
    }
}
