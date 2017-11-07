using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Tower_of_Hanoi
{
    class Program
    {
        private static int stepsTaken = 0;
        private static Stack<int> source;
        private static readonly Stack<int> spare = new Stack<int>();
        private static readonly Stack<int> destination = new Stack<int>();

        static void Main(string[] args)
        {
            int numberOfDiscks = int.Parse(Console.ReadLine());
            var range = Enumerable.Range(1, numberOfDiscks).Reverse();
            source = new Stack<int>(range);
            PrintRots();
            MoveDisks(numberOfDiscks, source, spare, destination);
        }

        private static void MoveDisks(int bottomDisk, Stack<int> source, Stack<int> spare, Stack<int> destination)
        {
            if (bottomDisk == 1)
            {
                destination.Push(source.Pop());
                stepsTaken++;
                //Console.WriteLine($"Steps #{stepsTaken}: Moved disk {bottomDisk}");
                Console.WriteLine($"Step #{stepsTaken}: Moved disk");
                PrintRots();
            }
            else
            {
                MoveDisks(bottomDisk - 1, source, destination, spare);
                destination.Push(source.Pop());
                stepsTaken++;
                //Console.WriteLine($"Steps #{stepsTaken}: Moved disk {bottomDisk}");
                Console.WriteLine($"Step #{stepsTaken}: Moved disk");
                PrintRots();
                MoveDisks(bottomDisk - 1, spare, source, destination);
            }
        }

        private static void PrintRots()
        {
            Console.WriteLine($"Source: {string.Join(", ", source.Reverse())}");
            Console.WriteLine($"Destination: {string.Join(", ", destination.Reverse())}");
            Console.WriteLine($"Spare: {string.Join(", ", spare.Reverse())}");
            Console.WriteLine();
        }
    }
}
