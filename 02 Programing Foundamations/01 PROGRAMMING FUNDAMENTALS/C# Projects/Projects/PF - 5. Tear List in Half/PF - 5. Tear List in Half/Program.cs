using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___5.Tear_List_in_Half
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> InputLetters = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> FirstLaftOfLetter = new List<int>();
            List<int> SecondLaftOfLetter = new List<int>();
            for (int i = 0; i < InputLetters.Count; i++)
            {
                if (i < InputLetters.Count / 2) SecondLaftOfLetter.Add(InputLetters[i]);
                else FirstLaftOfLetter.Add(InputLetters[i]);
            }
            List<int> NewList = new List<int>();
            for (int i = 0; i < FirstLaftOfLetter.Count; i++)
            {
                int A = FirstLaftOfLetter[i];
                int First = A / 10;
                int Second = A % 10;
                NewList.Add(First);
                NewList.Add(SecondLaftOfLetter[i]);
                NewList.Add(Second);
            }
            Console.WriteLine(string.Join(" ", NewList));
        }
    }
}
