using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> possitiveNumbers = new List<int>();
            foreach(var i in numbers)
            {
                if (i >= 0) possitiveNumbers.Add(i);
            }
            if (possitiveNumbers.Count==0)
                Console.WriteLine("empty");
            else
            {
                possitiveNumbers.Reverse();
                Console.WriteLine(string.Join(" ", possitiveNumbers));
            }                
        }
    }
}
