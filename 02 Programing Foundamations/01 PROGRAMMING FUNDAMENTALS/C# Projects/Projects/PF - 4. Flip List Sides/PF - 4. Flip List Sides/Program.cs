using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___4.Flip_List_Sides
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> InputLetters = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> ReversedLetters = new List<int>();
            ReversedLetters.Add(InputLetters[0]);
            for (int i = InputLetters.Count - 2; i >= 1; i--)
            {
                ReversedLetters.Add(InputLetters[i]);
            }
            ReversedLetters.Add(InputLetters[InputLetters.Count - 1]);
            Console.WriteLine(string.Join(" ", ReversedLetters));
        }
    }
}
