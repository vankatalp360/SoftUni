using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] InputLists = Console.ReadLine().Trim().Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            List<int> Input = new List<int>();
            foreach (var word in InputLists.Reverse())
            {
                foreach (int i in word.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse))
                {
                    Input.Add(i);
                }
            }
            Console.WriteLine(string.Join(" ", Input));
        }
    }
}
