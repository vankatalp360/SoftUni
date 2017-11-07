using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FP___2.Longest_Increasing_Subsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] elements = { ' ', ',' };
            int[] sequance = Console.ReadLine()
              .Split(elements, StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToArray();

            int[] lenghtElements = new int[sequance.Length];
            int[] previousElements = new int[sequance.Length];
            int maxlenght = 0;
            int lastIndex = -1;

            for (int i = 0; i < sequance.Length; i++)
            {
                lenghtElements[i] = 1;
                previousElements[i] = -1;

                for (int j = 0; j <= i - 1; j++)
                {
                    if (sequance[j] < sequance[i])
                    {
                        if (lenghtElements[i] <= lenghtElements[j])
                        {
                            lenghtElements[i] = lenghtElements[j] + 1;
                            previousElements[i] = j;
                        }
                    }
                }
                if (lenghtElements[i] > maxlenght)
                {
                    maxlenght = lenghtElements[i];
                    lastIndex = i;
                }
            }
            var longestSeq = new List<int>();
            for (int i = 0; i < maxlenght; i++)
            {
                longestSeq.Add(sequance[lastIndex]);
                lastIndex = previousElements[lastIndex];
            }
            longestSeq.Reverse();
            Console.WriteLine(string.Join(" ", longestSeq));
        }
    }
}
