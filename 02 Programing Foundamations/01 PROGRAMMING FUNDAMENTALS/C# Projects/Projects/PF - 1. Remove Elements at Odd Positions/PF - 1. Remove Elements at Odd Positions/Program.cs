using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___1.Remove_Elements_at_Odd_Positions
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> InputLetters = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            for (int i = 0; i< InputLetters.Count;i++)
            {
                InputLetters.Remove(InputLetters[i]);
            }
            Console.WriteLine(string.Join("", InputLetters));
        }
    }
}
