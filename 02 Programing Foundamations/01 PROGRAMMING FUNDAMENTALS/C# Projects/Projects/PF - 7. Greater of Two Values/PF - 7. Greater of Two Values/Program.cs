using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___7.Greater_of_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            string Type = Console.ReadLine();
            if (Type=="int")
            {
                int First = int.Parse(Console.ReadLine());
                int Second = int.Parse(Console.ReadLine());
                int Max = GetMax(First, Second);
                Console.WriteLine(Max);
            }
            else if (Type=="char")
            {
                char First = char.Parse(Console.ReadLine());
                char Second = char.Parse(Console.ReadLine());
                char Max = GetMax(First, Second);
                Console.WriteLine(Max);
            }
            else if (Type == "string")
            {
                string First = Console.ReadLine();
                string Second = Console.ReadLine();
                string Max = GetMax(First, Second);
                Console.WriteLine(Max);
            }
           
        }
        static int GetMax ( int first, int second)
        {
            if (first >= second) return first;
            else return second;
        }
        static char GetMax(char first, char second)
        {
            if (first >= second) return first;
            else return second;
        }
        static string GetMax(string first, string second)
        {
            if (first.CompareTo(second)>=0) return first;
            else return second;
        }
    }
}
