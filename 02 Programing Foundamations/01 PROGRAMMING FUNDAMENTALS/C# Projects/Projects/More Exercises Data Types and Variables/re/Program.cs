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
            switch (eddOrOdd)
            {
                case "odd":
                    add = 1;
                    break;
                default:
                    add = 0;
                    break;
            }
            string letter = null;
            for (int i = 1; i <= number; i++)
            {
                string currentWord = Console.ReadLine();
                if (i % 2 == add) letter = letter + currentWord + delimiter;
            }
            letter = letter.Remove(letter.Length - 1,1);
            Console.WriteLine(letter);
        }
    }
}
