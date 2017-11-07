using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.Condense_Array_to_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> Elements = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            while (Elements.Count != 1)
            {
                List<int> TempList = new List<int>();
                for (int i = 0; i < Elements.Count - 1; i++)
                {
                    int temp = Elements[i] + Elements[i + 1];
                    TempList.Add(temp);
                }
                Elements.Clear();
                foreach (int element in TempList)
                {
                    Elements.Add(element);
                }
                TempList.Clear();
            }
            Console.WriteLine(string.Join(" ", Elements));
        }
    }
}
