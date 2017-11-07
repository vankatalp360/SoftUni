using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Change_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            string[] command = Console.ReadLine().Split(' ');
            while (command[0] != "Odd" && command[0] != "Even")
            {
                ModifyTheList(numbers, command);
                command = Console.ReadLine().Split(' ');
            }
            PrintArray(numbers, command[0]);
        }

        private static void ModifyTheList(List<int> numbers, string[] command)
        {
            switch (command[0])
            {
                case "Delete":
                    int elements = int.Parse(command[1]);
                    numbers.RemoveAll(item => item == elements);
                    break;
                case "Insert":
                    int element = int.Parse(command[1]);
                    int possition = int.Parse(command[2]);
                    if (numbers.Count == 0) numbers.Add(element);
                    else
                    {
                        if (possition < 0) break;
                        if (possition > numbers.Count) possition = possition % numbers.Count;
                        numbers.Insert(possition, element);                        
                    }
                    break;
                default:
                    Console.WriteLine("Incorrect Input!");
                    break;
            }
           //Console.WriteLine(string.Join(" ", numbers));
        }

        private static void PrintArray(List<int> numbers, string command)
        {
            int index;
            if (command == "Odd") index = 1; else index = 0;
            foreach (int number in numbers)
            {
                if (number % 2 == index) Console.Write(number + " ");
            }
            Console.WriteLine();
        }
    }
}
