using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_7.Take_Skip_Rope
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] numbersList = input.ToCharArray().Where(x => x >= 48 && x <= 57).ToArray();
            int[] takeList = numbersList.Where((x, index) => index % 2 == 0).Select(x => x.ToString()).Select(int.Parse).ToArray();
            int[] skipList = numbersList.Where((x, index) => index % 2 == 1).Select(x => x.ToString()).Select(int.Parse).ToArray();
            char[] letters = input.ToCharArray().Where(x => x < 48 || x > 57).ToArray();
            string result = null;
            int total = 0;
            for (int i = 0; i < skipList.Length; i++)
            {
                result = string.Concat(result, string.Join("", letters.Skip(total).Take(takeList[i])));
                total += skipList[i] + takeList[i];
            }
            Console.WriteLine(result);
        }
    }
}
