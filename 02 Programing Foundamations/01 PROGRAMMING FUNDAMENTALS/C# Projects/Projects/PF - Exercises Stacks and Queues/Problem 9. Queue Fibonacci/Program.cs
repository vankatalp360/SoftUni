using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_9.Queue_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<long> Fib = new Queue<long>();
            Fib.Enqueue(0);
            Fib.Enqueue(1);
            for (int k = 2; k <= n; k++)
            {
                long prev2 = Fib.Dequeue();
                long prev1 = Fib.Peek();
                long current = prev1 + prev2;
                Fib.Enqueue(current);
            }
            Fib.Dequeue();
            Console.WriteLine(Fib.Peek());
        }
    }
}
