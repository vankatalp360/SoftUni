using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '(')
                {
                    stack.Push(i);
                }
                if (text[i] == ')')
                {
                    int start = stack.Pop();
                    Console.WriteLine(text.Substring(start, i - start + 1));
                }
            }
        }
    }
}
