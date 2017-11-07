using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_9.Make_a_Word
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[] word=new char [n];
            for (int i =0; i <n;i++)
            {
                word[i] = char.Parse(Console.ReadLine());
            }
            Console.WriteLine($"The word is: {string.Join("",word)}");
        }
    }
}
