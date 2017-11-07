using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem_9.Melrah_Shake
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = Console.ReadLine();
            while (true)
            {
                int textLenght = text.Length;
                int patternLenght = pattern.Length;
                if (patternLenght == 0) break;
                int firstIndexOfPattern = text.IndexOf(pattern);
                int lastIndexOfPatternc = text.LastIndexOf(pattern);
                if (firstIndexOfPattern != -1 && lastIndexOfPatternc != -1 && firstIndexOfPattern != lastIndexOfPatternc)
                {
                    string text1 = string.Join("", text.Take(firstIndexOfPattern));
                    string text2 = string.Join("", text.Skip(firstIndexOfPattern + patternLenght).Take(lastIndexOfPatternc - firstIndexOfPattern - patternLenght));
                    string text3 = string.Join("", text.Skip(lastIndexOfPatternc + patternLenght).Take(textLenght - lastIndexOfPatternc - patternLenght));
                    text = text.Remove(lastIndexOfPatternc, patternLenght);
                    text = text.Remove(firstIndexOfPattern, patternLenght);
                    Console.WriteLine("Shaked it.");
                    int index = patternLenght / 2;
                    pattern = pattern.Remove(index, 1);
                }
                else break;
            }
            Console.WriteLine("No shake.");
            Console.WriteLine(text);
        }
    }
}
