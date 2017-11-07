using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___6.Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] Array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int MaxLetter = 0;
            int MaxLetterLenght = 0;
            for (int i = 0; i < Array.Length; i++)
            {
                int pos = i;
                var result = FindLongestArrayFromChar(Array, pos);
                if (MaxLetterLenght < result.Value)
                {
                    MaxLetter = result.Key;
                    MaxLetterLenght = result.Value;
                }
                i = pos + result.Value - 1;
            }
            PrintMaxArray(MaxLetter, MaxLetterLenght);
        }
        private static KeyValuePair<int, int> FindLongestArrayFromChar(int[] array, int N)
        {
            int Lenght = 1;
            int CurrentNumber = array[N];
            for (int i = N + 1; i < array.Length; i++)
            {
                int NextNumber = array[i];
                if (CurrentNumber == NextNumber)
                {
                    Lenght++;
                    CurrentNumber = NextNumber;
                }
                else break;
            }
            var KeyValuePair = new KeyValuePair<int, int>(CurrentNumber, Lenght);
            return KeyValuePair;
        }
        private static void PrintMaxArray(int MaxLetter, int MaxLetterLenght)
        {
            for (int i = 1; i <= MaxLetterLenght; i++)
            {
                Console.Write(MaxLetter);
                if (i!= MaxLetterLenght) Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}
