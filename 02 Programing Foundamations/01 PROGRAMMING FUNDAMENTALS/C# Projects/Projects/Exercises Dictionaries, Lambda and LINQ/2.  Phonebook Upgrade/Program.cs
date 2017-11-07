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
            List<string> Names = new List<string>();
            List<string> Phones = new List<string>();

            while (true)
            {
                string[] command = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (command[0] == "END") break;
                if (command[0] == "A")
                {
                    if (!Names.Contains(command[1]))
                    {

                        Names.Add(command[1]);
                        Phones.Add(command[2]);
                    }
                    else
                    {
                        int possition = Names.IndexOf(command[1]);
                        Phones.RemoveAt(possition);
                        Phones.Insert(possition, command[2]);
                    }
                }
                else if (command[0] == "S")
                {
                    if (!Names.Contains(command[1]))
                    {
                        Console.WriteLine($"Contact {command[1]} does not exist.");
                    }
                    else
                    {
                        int index = Names.IndexOf(command[1]);
                        Console.WriteLine($"{ command[1]} -> { Phones[index]}");
                    }
                }
                if (command[0] == "ListAll")
                {
                    Dictionary<string, string> Phonebook = new Dictionary<string, string>();
                    List<string> SortedNames = new List<string>();
                   foreach(var name in Names)
                    {
                        SortedNames.Add(name);
                    }
                    SortedNames.Sort();
                    foreach (var name in SortedNames)
                    {
                        int index = Names.IndexOf(name);
                        Phonebook[name] = Phones[index];
                    }
                    foreach(var pair in Phonebook)
                    {
                        Console.WriteLine($"{pair.Key} -> {pair.Value}");
                    }
                }
            }
        }
    }
}
