using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___8.Most_Frequent_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sequance = Console.ReadLine()
                 .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();
            int maxStart = sequance[0];
            int maxLen = 1;


            for (int i = 0; i < sequance.Length; i++)
            {
                int currentStart = sequance[i];
                int currentLen = 1;
                for (int j = i + 1; j < sequance.Length; j++)
                {

                    if (sequance[i] == sequance[j]) currentLen++;
                }
                if (currentLen > maxLen)
                {
                    maxStart = currentStart;
                    maxLen = currentLen;
                }
            }
            for (int i = 1; i <= maxLen; i++)
            {
                if ( i != maxLen) Console.Write(maxStart+" ");
                else Console.WriteLine(maxStart);
            }
        }
    }
}
