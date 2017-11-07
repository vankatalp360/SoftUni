using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Sum_Reversed_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            int sum = 0;
            foreach (var i in input)
            {
                char[] cur = i.ToCharArray();
                sum += int.Parse(string.Join("", cur.Reverse()));
            }
            Console.WriteLine(sum);
        }
    }
}
