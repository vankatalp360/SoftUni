using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___3.Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> InputNumberList = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            while (true)
            {
                string[] CommandLine = Console.ReadLine().Split(' ');
                switch (CommandLine[0])
                {
                    case "add":
                        AddElement(InputNumberList, int.Parse(CommandLine[1]), int.Parse(CommandLine[2]));
                        break;
                    case "addMany":
                        AddSetOfElements(CommandLine, InputNumberList);
                        break;
                    case "contains":
                        DoesContainTheElement(InputNumberList, int.Parse(CommandLine[1]));
                        break;
                    case "remove":
                        RemoveElementOfTheList(InputNumberList, int.Parse(CommandLine[1]));
                        break;
                    case "shift":
                        ShiftElementToTheEnd(InputNumberList, int.Parse(CommandLine[1]));
                        break;
                    case "sumPairs":
                        SumListElementsByPairs(InputNumberList);
                        break;
                    case "print":
                        PrintArray(InputNumberList);
                        break;
                    default:
                        Console.WriteLine("Invalide command! Try again.");
                        break;
                }
                if (CommandLine[0] == "print") break;
            }
        }
        private static void SumListElementsByPairs(List<int> InputNumberList)
        {
            List<int> TempList = new List<int>();
            if (InputNumberList.Count % 2 != 0) InputNumberList.Add(0);
            for (int i = 0; i < InputNumberList.Count - 1; i += 2)
            {
                TempList.Add(InputNumberList[i] + InputNumberList[i + 1]);
            }
            InputNumberList.Clear();
            foreach (int i in TempList)
            {
                InputNumberList.Add(i);
            }
            TempList.Clear();
        }
        private static void ShiftElementToTheEnd(List<int> InputNumberList, int Element)
        {
            for (int i = 0; i < Element%InputNumberList.Count; i++)
            {
                int temp = InputNumberList[0];
                RemoveElementOfTheList(InputNumberList, 0);
                InputNumberList.Add(temp);
            }
        }
        private static void RemoveElementOfTheList(List<int> InputNumberList, int Element)
        {
            InputNumberList.RemoveAt(Element);
        }
        private static void DoesContainTheElement(List<int> InputNumberList, int Element)
        {
            Console.WriteLine(InputNumberList.IndexOf(Element));
        }
        private static void AddSetOfElements(string[] CommandLine, List<int> InputNumberList)
        {
            int Index = int.Parse(CommandLine[1]);
            int counter = 0;
            for (int i = 2; i < CommandLine.Length; i++)
            {
                int Element = int.Parse(CommandLine[i]);
                AddElement(InputNumberList, Index + counter, Element);
                counter++;
            }
        }
        private static void AddElement(List<int> InputNumberList, int Index, int Element)
        {
            InputNumberList.Insert(Index, Element);
        }
        private static void PrintArray(List<int> InputNumberList)
        {
            Console.WriteLine($"[{string.Join(", ", InputNumberList)}]");
        }
    }
}
