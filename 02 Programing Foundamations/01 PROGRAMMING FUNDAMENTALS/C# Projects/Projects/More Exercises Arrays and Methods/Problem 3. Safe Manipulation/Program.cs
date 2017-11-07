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
            while (true)
            {
                string[] command = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (command[0] == "END") break;
                switch (command[0])
                {
                    case "Reverse":
                        words = words.Reverse().ToArray();
                        break;
                    case "Distinct":
                        words = words.Distinct().ToArray();
                        break;
                    case "Replace":
                        int index;
                        bool result = int.TryParse(command[1], out index);
                        if (result == false||index>= words.Length|| index <0)
                        {
                            Console.WriteLine("Invalid input!");
                        }
                        else
                        {
                            words[index] = command[2];
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }
            }
            Console.WriteLine(string.Join(", ", words));
        }
    }
}
