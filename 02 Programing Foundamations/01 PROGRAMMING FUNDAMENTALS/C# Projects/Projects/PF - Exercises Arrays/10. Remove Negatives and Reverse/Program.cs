using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Remove_Negatives_and_Reverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> Elements = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            for (int i = Elements.Count - 1; i >= 0; i--)
            {
                if (Elements[i] < 0) Elements.RemoveAt(i);
            }
            Elements.Reverse();
            if (Elements.Count == 0) Console.WriteLine("empty");
            else
                Console.WriteLine(string.Join(" ", Elements));
        }
    }
}
