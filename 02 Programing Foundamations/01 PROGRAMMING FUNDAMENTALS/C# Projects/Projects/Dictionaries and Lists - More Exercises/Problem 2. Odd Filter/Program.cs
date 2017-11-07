using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Odd_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).Where(x => x % 2 == 0).ToArray();
            int[] output = new int[input.Length];
            if (input.Length == 1) output[0] = input[0] - 1;
            else
                for (int i = 0; i < input.Length; i++)
                {
                    int total = 0;
                    for (int j = 0; j < input.Length; j++)
                    {
                        if (i == j) continue;
                        total += input[j];
                    }
                    double average = total / (input.Length - 1);
                    if (input[i] < average) output[i] = input[i] - 1;
                    else output[i] = input[i] + 1;
                }
            Console.WriteLine(string.Join(" ", output));
        }
    }
}
