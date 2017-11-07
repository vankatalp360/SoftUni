using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Sum_Reversed_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            int sum = 0;
            /// <summary>
            /// Receives every string from input, parsed it and add it's value to total sum.
            /// It does NOT work with negative values!!!
            /// </summary>
            foreach (var i in input)
            {
                sum += int.Parse(StringHelper.ReverseString(i));
            }
            Console.WriteLine(sum);
        }
    }
}
static class StringHelper
{
    /// <summary>
    /// Receives string and returns the string with its letters reversed.
    /// </summary>
    public static string ReverseString(string s)
    {
        char[] arr = s.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }
}
