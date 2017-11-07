using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Search_for_a_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> inputNumbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            if (numbers[0] >= 0 && numbers[0] <= inputNumbers.Count)
                inputNumbers.RemoveRange(numbers[0], inputNumbers.Count - numbers[0]);
            //Console.WriteLine(string.Join(" ", inputNumbers));
            if (numbers[1] >= 0 && numbers[1] <= inputNumbers.Count)
                inputNumbers.RemoveRange(0, numbers[1]);
            //Console.WriteLine(string.Join(" ", inputNumbers));
            if (inputNumbers.Contains(numbers[2]))
                Console.WriteLine("YES!");
            else
                Console.WriteLine("NO!");
        }
    }
}
