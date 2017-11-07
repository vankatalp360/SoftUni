using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___4.Sieve_of_Eratosthenes
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            bool[] Array = new bool[N + 1];
            MakeTheArrayTrue(Array, N + 1);
            Array[0] = Array[1] = false;
            for (int i = 2; i <= N; i++)
            {
                if (Array[i] == true) Array[i] = IsNumberPrime(i);
                if (Array[i] == true) CalculateNextNumber(Array, i, N);
            }
            PrintArray(Array);
        }
        private static void MakeTheArrayTrue(bool[] array, int N)
        {
            for (int i = 0; i < N; i++)
            {
                array[i] = true;
            }
        }
        private static void CalculateNextNumber(bool[] array, int i, int N)
        {
            for (int j = 2 * i; j <= N - 1; j += i)
            {
                array[j] = false;
            }
        }
        private static bool IsNumberPrime(int number)
        {
            bool Result = true;
            for (long i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    Result = false;
                    break;
                }
            }
            return Result;
        }
        private static void PrintArray(bool[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == true) Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
