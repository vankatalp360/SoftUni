using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___7.Greeting
{
    class Program
    {
        static void Main(string[] args)
        {
            string FirstName = Console.ReadLine();
            string LastName = Console.ReadLine();
            int Age = int.Parse(Console.ReadLine());
            //Console.WriteLine("Hello, {0} {1}. You are {2} years old.", FirstName, LastName,Age);
            Console.WriteLine($"Hello, {FirstName} {LastName}. You are {Age} years old.");
        }
    }
}
