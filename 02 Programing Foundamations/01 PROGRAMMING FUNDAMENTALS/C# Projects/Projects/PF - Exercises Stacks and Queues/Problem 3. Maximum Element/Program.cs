using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3.Maximum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int nQueries = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();
            Stack<int> maxEls = new Stack<int>();
            int max = int.MinValue;
            for (int i = 0; i < nQueries; i++)
            {
                int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                switch (input[0])
                {
                    case 1:
                        stack.Push(input[1]);
                        if (max<input[1])
                        {                            
                            max = input[1];
                            maxEls.Push(input[1]);
                        }
                        else
                        {
                            maxEls.Push(max);
                        }
                        break;
                    case 2:
                        stack.Pop();
                        maxEls.Pop();
                        if (maxEls.Count != 0)
                        {
                            max = maxEls.Peek();
                        }
                        else
                        {
                            max = int.MinValue;
                        }
                        break;
                    case 3:
                        Console.WriteLine(maxEls.Peek());
                        break;
                }
            }
        }     
    }
}
