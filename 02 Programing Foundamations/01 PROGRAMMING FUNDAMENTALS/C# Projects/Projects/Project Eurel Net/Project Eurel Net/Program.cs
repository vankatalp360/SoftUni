using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Eurel_Net
{
    class Program
    {
        static void Main(string[] args)
        {
            long largestPalindrome = 0;
            int fist=0;
            int second=0;
            for (int i = 100; i <= 999; i++)
            {
                for (int j = 100; j <= 999; j++)
                {
                    if (Check((i * j).ToString().ToCharArray()))
                    {
                        if (largestPalindrome<=i*j)
                        {
                            fist = i;
                            second = j;
                            largestPalindrome = i * j;
                        }
                    }
                }
            }
            Console.WriteLine($"{fist}*{second}={largestPalindrome}");
        }
        private static bool Check(char[] arr)
        {
            bool result = true;
            for (int i = 0; i <= arr.Length / 2; i++)
            {
                if (arr[i] != arr[arr.Length - i - 1])
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
    }
}
