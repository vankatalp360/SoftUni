using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___2.Append_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] InputLists = Console.ReadLine().Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            List<int>[] Input = new List<int>[InputLists.Length];
            for (int i = 0; i < InputLists.Length; i++)
            {
                Input[i] = InputLists[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            }
            for (int i = Input.Count() - 1; i >= 0; i--)
            {
                for (int j = 0; j < Input[i].Count(); j++)
                {
                    Console.Write(Input[i][j]);
                    if (i > 0 || j < Input[i].Count() - 1) Console.Write(" ");
                }
            }
        }
    }
}
