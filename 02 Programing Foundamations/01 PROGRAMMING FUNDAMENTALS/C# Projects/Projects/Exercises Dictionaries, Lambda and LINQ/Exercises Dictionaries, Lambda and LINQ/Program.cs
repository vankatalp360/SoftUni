using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises_Dictionaries__Lambda_and_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> Phonebook = new Dictionary<string, string>();
            while (true)
            {
                string[] command = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (command[0] == "END") return;
                if (command[0] == "A")
                {
                    Phonebook[command[1]] = command[2];
                }
                else if (command[0] == "S")
                {
                    if (!Phonebook.ContainsKey(command[1]))
                    {
                        Console.WriteLine($"Contact {command[1]} does not exist.");
                    }
                    else
                    {
                        Console.WriteLine($"{ command[1]} -> { Phonebook[command[1]]}");
                    }
                }
            }
        }
    }
}
