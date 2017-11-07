using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Phonebook_Upgrade
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, string> Phonebook = new SortedDictionary<string, string>();
            while (true)
            {
                string[] command = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (command[0] == "END") break;
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
                if (command[0] == "ListAll")
                {
                    foreach (var pair in Phonebook)
                    {
                        Console.WriteLine($"{pair.Key} -> {pair.Value}");
                    }
                }
            }
        }
    }
}
