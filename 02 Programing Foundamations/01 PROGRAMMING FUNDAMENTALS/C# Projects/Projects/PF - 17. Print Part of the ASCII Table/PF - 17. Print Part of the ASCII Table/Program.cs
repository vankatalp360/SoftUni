using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___17.Print_Part_of_the_ASCII_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int StartChar = int.Parse(Console.ReadLine());
            int EndChar = int.Parse(Console.ReadLine());
            for (char i =(char)StartChar; i<=EndChar;i++)
            {
                Console.Write(i);
                if (i != EndChar) Console.Write(' ');
            }
            Console.WriteLine();
        }
    }
}
