using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Append_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> letters = Console.ReadLine().Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            letters.Reverse();
            List<int> result = new List<int>();
            foreach (var letter in letters)
            {
                List<int> numbers = letter.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                foreach (var number in numbers)
                {
                    result.Add(number);
                }
            }
            Console.WriteLine(string.Join(" ",result));
        }
    }
}
