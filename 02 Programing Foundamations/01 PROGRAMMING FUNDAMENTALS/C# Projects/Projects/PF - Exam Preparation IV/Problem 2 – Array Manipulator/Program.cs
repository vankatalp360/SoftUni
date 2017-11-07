using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2___Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] Numbers = Console.ReadLine().Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            while (true)
            {

                string[] Letters = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (Letters[0] == "end") break;
                switch (Letters[0])
                {
                    case "exchange":
                        int index = int.Parse(Letters[1]);
                        if (index < 0 || index >= Numbers.Length)
                        {
                            Console.WriteLine("Invalid index");
                            break;
                        }
                        Numbers = ExchangeArrayLetter(Numbers, int.Parse(Letters[1]));
                        break;
                    case "max":
                        FindMaxOddOrEven(Numbers, Letters[1]);
                        break;
                    case "min":
                        FindMinOddOrEven(Numbers, Letters[1]);
                        break;
                    case "first":
                        CheckCount(Numbers, int.Parse(Letters[1]), Letters[2], "first");
                        break;
                    case "last":
                        CheckCount(Numbers, int.Parse(Letters[1]), Letters[2], "last");
                        break;
                }

            }
            PrintArray(Numbers);
        }
        private static int[] ExchangeArrayLetter(int[] Numbers, int index)
        {
            int length = Numbers.Length;
            int[] Temp = new int[length];
            for (int i = 0; i < length; i++)
            {
                if (i < length - index - 1) Temp[i] = Numbers[i + index + 1];
                else Temp[i] = Numbers[-length + index + i + 1];
            }
            return Temp;
        }
        private static void PrintArray(int[] Numbers)
        {
            Console.WriteLine($"[{string.Join(", ", Numbers)}]");
        }
        private static void PrintReversedArray(int[] Numbers)
        {
            Console.WriteLine($"[{string.Join(", ", Numbers.Reverse())}]");
        }
        private static void FindMaxOddOrEven(int[] Numbers, string Input)
        {
            int index;
            int current = int.MinValue;
            int possition = -1;
            if (Input == "odd") index = 1; else index = 0;
            for (int i = 0; i < Numbers.Length; i++)
            {
                if (Numbers[i] % 2 == index)
                {
                    if (current <= Numbers[i])
                    {
                        current = Numbers[i];
                        possition = i;
                    }
                }
            }
            if (possition != -1) Console.WriteLine(possition);
            else Console.WriteLine($"No matches");
        }
        private static void FindMinOddOrEven(int[] Numbers, string Input)
        {
            int index;
            int current = int.MaxValue;
            int possition = -1;
            if (Input == "odd") index = 1; else index = 0;
            for (int i = 0; i < Numbers.Length; i++)
            {
                if (Numbers[i] % 2 == index)
                {
                    if (current >= Numbers[i])
                    {
                        current = Numbers[i];
                        possition = i;
                    }
                }
            }
            if (possition != -1) Console.WriteLine(possition);
            else Console.WriteLine($"No matches");
        }
        private static void FindFirstCurrentNumberOfOddOrEven(int[] Numbers, int number, string Input)
        {
            int index;
            int counter = 0;
            int[] temp = new int[counter];
            if (Input == "odd") index = 1; else index = 0;
            for (int i = 0; i < Numbers.Length; i++)
            {
                if (Numbers[i] % 2 == index)
                {
                    counter++;
                    if (counter - 1 == number) break;
                    else
                    {
                        Array.Resize(ref temp, counter);
                        temp[counter - 1] = Numbers[i];
                    }
                }
            }
            PrintArray(temp);
        }
        private static void FindLastCurrentNumberOfOddOrEven(int[] Numbers, int number, string Input)
        {
            int index;
            int counter = 0;
            int[] temp = new int[counter];
            if (Input == "odd") index = 1; else index = 0;
            for (int i = Numbers.Length - 1; i >= 0; i--)
            {
                if (Numbers[i] % 2 == index)
                {
                    counter++;
                    if (counter - 1 == number) break;
                    else
                    {
                        Array.Resize(ref temp, counter);
                        temp[counter - 1] = Numbers[i];
                    }
                }
            }
            PrintReversedArray(temp);
        }
        private static void CheckCount(int[] Numbers, int number, string Input, string command)
        {
            if (Numbers.Length >= number)
            {
                if (command == "first") FindFirstCurrentNumberOfOddOrEven(Numbers, number, Input);
                else FindLastCurrentNumberOfOddOrEven(Numbers, number, Input);
            }
            else Console.WriteLine("Invalid count");
        }
    }
}
