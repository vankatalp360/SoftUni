using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4.Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            
            Queue<int> eqEl = new Queue<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
                       
            for (int i = 0; i < input[1]; i++)
            {
                eqEl.Dequeue();
            }
            if (eqEl.Count != 0)
            {
                int min = eqEl.Peek();
                foreach (int element in eqEl)
                {
                    if (element==input[2])
                    {
                        Console.WriteLine("true");
                        return;
                    }
                    if (element < min)
                        min = element;
                }
                Console.WriteLine(min);
            }
            else
            {
                Console.WriteLine("0");
            }
        }
    }
}
