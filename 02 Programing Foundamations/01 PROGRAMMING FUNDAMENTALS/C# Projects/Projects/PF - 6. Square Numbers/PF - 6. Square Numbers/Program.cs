using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___6.Square_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> InputNumbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> SquereNumbers = new List<int>();
            for (int i = 0; i < InputNumbers.Count; i++)
            {
                if (Math.Sqrt(InputNumbers[i]) == (int)Math.Sqrt(InputNumbers[i])) SquereNumbers.Add(InputNumbers[i]);
            }
            //SquereNumbers.Sort((a, b) => b.CompareTo(a));
            SquereNumbers.Sort();
            SquereNumbers.Reverse();
            Console.WriteLine(string.Join(" ", SquereNumbers));
        }
    }
}
