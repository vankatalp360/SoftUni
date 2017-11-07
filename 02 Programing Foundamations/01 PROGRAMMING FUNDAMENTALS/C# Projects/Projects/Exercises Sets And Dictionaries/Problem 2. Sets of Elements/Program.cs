using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sets = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            HashSet<int> nset = new HashSet<int>();
            HashSet<int> result = new HashSet<int>();
            for(int k = 0; k < sets[0]; k++)
            {
                nset.Add(int.Parse(Console.ReadLine()));
            }
            for (int k = 0; k < sets[1]; k++)
            {
                int current = int.Parse(Console.ReadLine());
                if (nset.Contains(current))
                {
                    result.Add(current);
                }
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
