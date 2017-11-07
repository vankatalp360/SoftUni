using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.Reverse_Numbers_with_a_Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split(' ').ToArray();
            Stack<string> rev = new Stack<string>();
            foreach(string num in nums)
            {
                rev.Push(num);
            }
            Console.WriteLine(string.Join(" ", rev));
        }
    }
}
