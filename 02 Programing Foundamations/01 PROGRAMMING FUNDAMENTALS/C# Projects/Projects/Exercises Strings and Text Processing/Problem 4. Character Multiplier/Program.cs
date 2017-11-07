using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4.Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();
            MultiplyTwoStrings(input[0], input[1]);
        }

        private static void MultiplyTwoStrings(string v1, string v2)
        {
            int sum = 0;
            int minLenght = Math.Min(v1.Length, v2.Length);
            for (int i = 0; i < minLenght ; i++)
            {
                sum +=v1[i]* v2[i];
            }
            string remain = v1.Substring(minLenght)+v2.Substring(minLenght);
            sum += remain.Select(x => (int)x).Sum();
            Console.WriteLine(sum);
        }
    }
}
