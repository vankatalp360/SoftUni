using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4.Array_Modifier
{
    class Program
    {
        static void Main(string[] args)
        {
            long [] numbers = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            while (true)
            {
                string[] commands = Console.ReadLine().Split(' ').ToArray();
                if (commands[0] == "end") break;
                ModifyArrayOfNumbers(numbers, commands);
            }
            PrintResult(numbers);
        }

        private static void ModifyArrayOfNumbers(long[] numbers, string[] commands)
        {
            switch (commands[0])
            {
                case "swap":
                    int index1 = int.Parse(commands[1]);
                    int index2 = int.Parse(commands[2]);
                    if (!CheckIfExist(index1, numbers.Length)) break;
                    if (!CheckIfExist(index2, numbers.Length)) break;
                    ChangePlaces(index1, index2, numbers);
                    break;
                case "multiply":
                    index1 = int.Parse(commands[1]);
                    index2 = int.Parse(commands[2]);
                    if (!CheckIfExist(index1, numbers.Length)) break;
                    if (!CheckIfExist(index2, numbers.Length)) break;
                    MultiplyElementByElement(index1, index2, numbers);
                    break;
                case "decrease":
                    DecreaseAllElements(numbers);
                    break;
            }
        }

        private static void DecreaseAllElements(long[] numbers)
        {
           for(int i = 0; i < numbers.Length;i++)
            {
                numbers[i] -= 1;
            }
        }

        private static void MultiplyElementByElement(int index1, int index2, long[] numbers)
        {
            numbers[index1] *= numbers[index2];
        }

        private static void ChangePlaces(int index1, int index2, long[] numbers)
        {
            long oldNumber = numbers[index1];
            numbers[index1] = numbers[index2];
            numbers[index2] = oldNumber;
        }

        private static bool CheckIfExist(int index, int max)
        {
            if (index < 0 || index >= max) return false;
            else return true;
        }

        private static void PrintResult(long[] numbers)
        {
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
