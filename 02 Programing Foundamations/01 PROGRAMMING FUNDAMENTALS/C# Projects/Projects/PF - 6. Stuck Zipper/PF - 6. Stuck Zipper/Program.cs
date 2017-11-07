using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___6.Stuck_Zipper
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> FirstLetter = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> SecondLetters = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int FirstLetterMinDigit = CalculateMaxDigit(FirstLetter);
            int SecondLetterMinDigit = CalculateMaxDigit(SecondLetters);
            int MinDigit = Math.Min(FirstLetterMinDigit, SecondLetterMinDigit);
            List<int> FirstLetterAfterRemoval = new List<int>();
            List<int> SecondLetterAfterRemoval = new List<int>();
            for (int i = 0; i < FirstLetter.Count; i++)
            {
                if (FirstLetter[i] / MinDigit <= 0) FirstLetterAfterRemoval.Add(FirstLetter[i]);
            }
            for (int i = 0; i < SecondLetters.Count; i++)
            {
                if (SecondLetters[i] / MinDigit <= 0) SecondLetterAfterRemoval.Add(SecondLetters[i]);
            }
            int MaxLenght = Math.Max(FirstLetterAfterRemoval.Count, SecondLetterAfterRemoval.Count);
            List<int> CombineLetter = new List<int>();
            for (int i = 0; i < MaxLenght; i++)
            {
                if (i < SecondLetterAfterRemoval.Count) CombineLetter.Add(SecondLetterAfterRemoval[i]);
                if (i <FirstLetterAfterRemoval.Count) CombineLetter.Add(FirstLetterAfterRemoval[i]);
            }
            Console.WriteLine(string.Join(" ", CombineLetter));
        }
        private static int CalculateMaxDigit(List<int> Letter)
        {
            int mindigit = int.MaxValue;
            for (int i = 0; i < Letter.Count; i++)
            {
                int currentdigit = 1;
                int temp = Math.Abs(Letter[i]);
                while (true)
                {
                    if (temp / 10 == 0) break;
                    else
                    {
                        currentdigit *= 10;
                        temp = temp / 10;
                    }
                }
                mindigit = Math.Min(mindigit, currentdigit);
            }
            return mindigit * 10;
        }
    }
}
