using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Sum_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> row1 = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> row2 = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> Newrow = new List<int>();
            for (int k = 0; k < Math.Max(row1.Count, row2.Count); k++)
            {
                Newrow.Add(row1[k%row1.Count] + row2[k % row2.Count]);
            }
            Console.WriteLine(string.Join(" ", Newrow));
        }
    }
}
