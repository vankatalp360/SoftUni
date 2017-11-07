using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_5.Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> Phonebook = new Dictionary<string, string>();
            string[] command = Console.ReadLine().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            while (command[0] != "search"&& command[0] != "stop")
            {
                Phonebook[command[0]] = command[1];
                command = Console.ReadLine().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            }
            command = Console.ReadLine().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            while (command[0] != "stop")
            {
                if (!Phonebook.ContainsKey(command[0]))
                {
                    Console.WriteLine($"Contact {command[0]} does not exist.");
                }
                else
                {
                    Console.WriteLine($"{ command[0]} -> { Phonebook[command[0]]}");
                }
                command = Console.ReadLine().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            }
        }
    }
}
