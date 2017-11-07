using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_5.Calculate_Sequence_with_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            long N = long.Parse(Console.ReadLine());
            Queue<long> sequence = new Queue<long>();
            sequence.Enqueue(N);
            long i = 1;

            while (true)
            {
                long s = sequence.Dequeue();
                Console.Write(s);
                Console.Write(" ");

                sequence.Enqueue(s + 1);
                i++;
                if (i == 50) break;

                sequence.Enqueue(2 * s + 1);
                i++;
                if (i == 50) break;

                sequence.Enqueue(s + 2);
                i++;
                if (i == 50) break;

            }
            Console.WriteLine(string.Join(" ",sequence));
        }
    }
}
