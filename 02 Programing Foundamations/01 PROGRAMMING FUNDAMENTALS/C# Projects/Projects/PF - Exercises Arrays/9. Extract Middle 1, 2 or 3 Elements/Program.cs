using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9.Extract_Middle_1__2_or_3_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> Elements = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int length = Elements.Count;
            List<int> Extract = new List<int>();
            if (length == 1) Extract = Elements;
            else if (length%2==0)
            {
                Extract.Add(Elements[length / 2 - 1]);
                Extract.Add(Elements[length / 2 ]);
            }
            else
            {
                Extract.Add(Elements[length / 2 - 1]);
                Extract.Add(Elements[length / 2 ]);
                Extract.Add(Elements[length / 2 + 1]);
            }
            Console.WriteLine("{ "+string.Join(", ", Extract)+ " }");
        }
    }
}
