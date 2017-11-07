using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_13.Decrypting_Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int numberOfLines = int.Parse(Console.ReadLine());
            string fullLetter = null;
            for (int i =1; i <=numberOfLines;i++)
            {
                char currentChar = char.Parse(Console.ReadLine());
                currentChar = (char)(currentChar+key);
                fullLetter += currentChar;
            }
            Console.WriteLine(fullLetter);
        }
    }
}
