using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___1.Remove_Negatives_and_Reverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> Input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> NewList = new List<int>();
            for (int i = 0; i < Input.Count; i++)
            {
                if (Input[i] >= 0) NewList.Add(Input[i]);
            }
            if (NewList.Count != 0)
            {
                for (int i = NewList.Count - 1; i >= 0; i--)
                {
                    Console.Write(NewList[i]);
                    if (i != 0) Console.Write(", ");
                }
                Console.WriteLine();
            }
            else Console.WriteLine("empty");
        }
    }
}
