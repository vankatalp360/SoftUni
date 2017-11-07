using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_9.Stack_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<long> Fib = new Stack<long>();
            Fib.Push(0);
            Fib.Push(1);
            for (int k = 2; k <= n; k++)
            {
                long prev1 = Fib.Pop();
                long prev2 = Fib.Peek();
                long current = prev1 + prev2;
                Fib.Push(prev1);
                Fib.Push(current);
            }
            Console.WriteLine(Fib.Peek());
        }
    }
}
