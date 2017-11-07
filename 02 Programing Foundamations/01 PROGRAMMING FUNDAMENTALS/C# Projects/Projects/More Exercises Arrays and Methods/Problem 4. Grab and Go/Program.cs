using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4.Grab_and_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
            long ïndex = long.Parse(Console.ReadLine());
            long possition;
            if (!numbers.Contains(ïndex))
                Console.WriteLine("No occurrences were found!");
            else
            {
                possition = Array.LastIndexOf(numbers, ïndex);
                long[] subArray = new long[possition];
                Array.Copy(numbers, subArray, possition);
                Console.WriteLine(subArray.Sum());
            }
        }
    }
}
