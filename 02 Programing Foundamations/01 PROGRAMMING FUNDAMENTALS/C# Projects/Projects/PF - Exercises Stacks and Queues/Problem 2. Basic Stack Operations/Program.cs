using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int N = input[0];

            int S = input[1];

            int X = input[2];

            int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>();
            foreach (int num in nums)
            {
                stack.Push(num);
            }

            for (int i = 0; i <  S; i++)
            {
                stack.Pop();
            }

            int minEl = int.MaxValue;

            foreach ( int num in stack)
            {
                if (X == num)
                {
                    Console.WriteLine("true");
                    return;
                }
                if (num <= minEl)
                {
                    minEl = num;
                }
            }
            if (stack.Count > 0)
                Console.WriteLine(minEl);
            else
                Console.WriteLine(0);
        }
    }
}
