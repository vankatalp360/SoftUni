using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Manipulate_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            int numberOfLines = int.Parse(Console.ReadLine());
            for (int i = 1; i <= numberOfLines; i++)
            {
                string[] command = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                switch (command[0])
                {
                    case "Reverse":
                        words = words.Reverse().ToArray();
                        break;
                    case "Distinct":
                        words = words.Distinct().ToArray();
                        break;
                    case "Replace":
                        int index = int.Parse(command[1]);
                        words[index] = command[2];
                        break;
                    default:
                        Console.WriteLine("Unknown operation!");
                        break;
                }
            }
            Console.WriteLine(string.Join(", ", words));
        }
    }
}
