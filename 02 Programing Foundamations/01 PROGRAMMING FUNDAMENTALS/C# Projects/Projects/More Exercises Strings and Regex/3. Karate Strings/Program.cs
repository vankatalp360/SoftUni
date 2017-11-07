using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _3.Karate_Strings
{
    class Program
    {
        static void Main(string[] args)
        {            
            string text = Console.ReadLine();
            char[] textInChars = text.ToCharArray();
            int totalStrainght = 0;
            int indexPunch = text.IndexOf('>');
            while(indexPunch!=-1)
            {
                
                int digitIndex = indexPunch + 1;
                if (digitIndex == text.Length) break;
                int digitLenght = 0;
                while (char.IsDigit(text[digitIndex]))
                {
                    digitLenght++;
                    digitIndex++;
                    if (digitIndex == text.Length) break;
                }
                string digit = string.Join("", textInChars.Skip(indexPunch + 1).Take(digitLenght));
                int currentStrainght;
                bool result = int.TryParse(digit, out currentStrainght);
                if (!result)
                {
                    indexPunch = text.IndexOf('>', indexPunch + 1);
                    continue;
                }
                totalStrainght += currentStrainght;
                int counter = 0;
                for (int i =1; i <= totalStrainght; i++)
                {
                    if (indexPunch + i >= text.Length) break;
                    if (text[indexPunch + i] == '>') break;
                    textInChars[indexPunch + i] = '0';
                    counter++;                         
                }
                totalStrainght -= counter;
                indexPunch = text.IndexOf('>',indexPunch+1);
            }
            Console.WriteLine(string.Join("",textInChars.Where(x=>x!='0')));
        }
    }
}
