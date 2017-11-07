using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_7.Play_Catch
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split(' ').ToArray();
            int counter = 0;
            while (true)
            {
                string[] commands = Console.ReadLine().Split(' ').ToArray();
                int error = 0;
                switch (commands[0])
                {
                    case "Replace":
                        arr = ReplaceElement(arr, commands, out error);
                        break;
                    case "Print":
                        PrintArrayExtract(arr, commands, out error);
                        break;
                    case "Show":
                        ShowArrayElement(arr, commands, out error);
                        break;
                    default:
                        break;
                }
                counter += error;
                if (counter == 3) break;
            }
            PrintArray(arr);
        }

        private static void ShowArrayElement(string[] arr, string[] commands, out int error)
        {
            error = 0;
            string index = commands[1];
            int numberOfIndex;
            bool variableTypeIndex = CheckVariableTypeInt(index, out numberOfIndex);
            if (!variableTypeIndex)
            {
                error = 1;
                return;
            }
            if (IndexExistInArray(arr, numberOfIndex))
            {
                arr = arr.Skip(numberOfIndex).Take(1).ToArray();
                PrintArray(arr);
            }
            else
            {
                error = 1;
                return;
            }
        }

        private static void PrintArrayExtract(string[] arr, string[] commands, out int error)
        {
            error = 0;
            string start = commands[1];
            string end = commands[2];
            int startIndex;
            bool variableTypeStart = CheckVariableTypeInt(start, out startIndex);
            if (!variableTypeStart)
            {
                error = 1;
                return;
            }
            int endIndex;
            bool variableTypeEnd = CheckVariableTypeInt(end, out endIndex);
            if (!variableTypeEnd)
            {
                error = 1;
                return;
            }
            if (PrintIndexExistInArray(arr, startIndex, endIndex))
            {
                arr = arr.Skip(startIndex).Take(endIndex - startIndex + 1).ToArray();
                PrintArray(arr);
            }
            else
            {
                error = 1;
                return;
            }
        }

        private static bool PrintIndexExistInArray(string[] arr, int start, int end)
        {
            if (start >= 0 && start <= end && end < arr.Length)
            {
                return true;
            }
            else
            {
                Console.WriteLine($"The index does not exist!");
                return false;
            }
        }

        private static string[] ReplaceElement(string[] arr, string[] commands, out int error)
        {
            error = 0;
            string index = commands[1];
            string element = commands[2];
            int numberOfIndex;
            bool variableTypeIndex = CheckVariableTypeInt(index, out numberOfIndex);
            if (!variableTypeIndex)
            {
                error = 1;
                return arr;
            }
            int numberOfElement;
            bool variableTypeElement = CheckVariableTypeInt(element, out numberOfElement);
            if (!variableTypeElement)
            {
                error = 1;
                return arr;
            }
            if (IndexExistInArray(arr, numberOfIndex))
            {
                arr[numberOfIndex] = element;
                return arr;
            }
            else
            {
                error = 1;
                return arr;
            }
        }

        private static bool CheckVariableTypeInt(string index, out int number)
        {
            bool result = int.TryParse(index, out number);
            if (!result)
            {
                Console.WriteLine($"The variable is not in the correct format!");
            }
            return result;
        }

        private static bool IndexExistInArray(string[] arr, int index)
        {
            if (index >= 0 && arr.Length > index)
            {
                return true;
            }
            else
            {
                Console.WriteLine($"The index does not exist!");
                return false;
            }
        }

        private static void PrintArray(string[] arr)
        {
            Console.WriteLine(string.Join(", ", arr));
        }
    }
}
