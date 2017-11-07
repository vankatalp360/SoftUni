using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> leftNumbers = numbers.Take(numbers.Count / 4).Reverse().ToList();
            numbers.Reverse();
            List<int> middleNumbers = numbers.Skip(numbers.Count / 4).Take(numbers.Count / 2).Reverse().ToList();
            List<int> rightNumbers = numbers.Take(numbers.Count / 4).ToList();
            for(int i = 0; i < numbers.Count / 2; i ++)
            {
                if (i < numbers.Count / 4) middleNumbers[i] += leftNumbers[i];
                else middleNumbers[i] += rightNumbers[i - numbers.Count / 4];
            }
            Console.WriteLine(string.Join(" ", middleNumbers));
        }
    }
}
