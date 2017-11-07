using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3___Rage_Quit
{
    class Program
    {
        static void Main(string[] args)
        {
            string InputLetter = Console.ReadLine().ToUpper();
            char[] Numbers = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            char[] AlphabeticUnique = InputLetter.Trim().ToCharArray();
            List<char> UniqueSymbols = new List<char>();
            foreach (char i in AlphabeticUnique)
            {
                if (!Numbers.Contains(i) && !UniqueSymbols.Contains(i) && i != ' ') UniqueSymbols.Add(i);
            }
            StringBuilder OutPutLetter = new StringBuilder();
            while (InputLetter.Length != 0)
            {
                char[] AlphabeticReverse = InputLetter.TrimEnd().ToCharArray();
                int index = 0;
                while (!Numbers.Contains(AlphabeticReverse[index]))
                {
                    index++;
                }
                string CurrentWord = InputLetter.Substring(0, index);

                int index2 = index;

                while (Numbers.Contains(AlphabeticReverse[index2]))
                {
                    index2++;
                    if (index2 == InputLetter.Length) break;
                }
                int CurrentNumber = int.Parse(InputLetter.Substring(index, index2 - index));
                InputLetter = InputLetter.Substring(index2);
                for (int i = 0; i < CurrentNumber; i++)
                {
                    OutPutLetter.Append(CurrentWord);
                }
            }
            Console.WriteLine($"Unique symbols used: {UniqueSymbols.Count}");
            Console.WriteLine(OutPutLetter);
        }
    }
}

