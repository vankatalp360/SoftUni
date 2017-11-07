using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_11.String_Concatenation
{
    class Program
    {
        static void Main(string[] args)
        {
            string delimiter = Console.ReadLine();
            string eddOrOdd = Console.ReadLine();
            int number = int.Parse(Console.ReadLine());
            int add;
            int size;
            switch (eddOrOdd)
            {
                case "odd":
                    add = 1;
                    if (number % 2 == 0) size = number / 2; else size = (number + 1) / 2;
                    break;
                default:
                    add = 0;
                    size = number / 2;
                    break;
            }
            string[] letter = new string[size];
            for (int i = 1; i <= number; i++)
            {
                string currentWord = Console.ReadLine();
                if (i % 2 == add) letter[i / 2-1+add] = currentWord;
            }
            Console.WriteLine(string.Join(delimiter, letter));
        }
    }
}
