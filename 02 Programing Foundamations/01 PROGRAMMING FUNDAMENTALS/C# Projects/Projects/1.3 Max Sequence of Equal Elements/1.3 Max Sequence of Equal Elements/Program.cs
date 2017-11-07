using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._3_Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] InputNumbers = Console.ReadLine()
                  .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                  .Select(int.Parse)
                  .ToArray();
            List<int> thelongestSubsequence = new List<int>();
            List<int> currentSubsequence = new List<int>();
            currentSubsequence.Add(InputNumbers[0]);
            for (int i =1; i<InputNumbers.Length;i++)
            {
                if (InputNumbers[i]==currentSubsequence[0])
                {
                    currentSubsequence.Add(InputNumbers[i]);
                }
                else
                {
                    if (currentSubsequence.Count>thelongestSubsequence.Count)
                    {
                        thelongestSubsequence.Clear();
                        foreach(int k in currentSubsequence)
                        {
                            thelongestSubsequence.Add(k);
                        }
                    }
                    currentSubsequence.Clear();
                    currentSubsequence.Add(InputNumbers[i]);
                }
            }

            if (currentSubsequence.Count > thelongestSubsequence.Count)
            {
                thelongestSubsequence.Clear();
                foreach (int k in currentSubsequence)
                {
                    thelongestSubsequence.Add(k);
                }
            }
            Console.WriteLine(string.Join(" ",thelongestSubsequence));
        }
    }
}
