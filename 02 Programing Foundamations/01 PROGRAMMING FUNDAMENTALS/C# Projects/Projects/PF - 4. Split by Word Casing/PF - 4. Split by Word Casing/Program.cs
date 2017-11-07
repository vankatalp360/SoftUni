using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___4.Split_by_Word_Casing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> InputList = Console.ReadLine().Split(new char[] { ',', ';', ':', '.', '!', '(', ')', '\'', '\"', '\\', '/', '[', ']', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> LowerCaseWords = new List<string>();
            List<string> MixedCaseWords = new List<string>();
            List<string> UpperCaseWords = new List<string>();
            for (int i = 0; i < InputList.Count; i++)
            {
                if (InputList[i].All(char.IsLower))
                {
                    LowerCaseWords.Add(InputList[i]);
                }
                else if (InputList[i].All(char.IsUpper))
                {
                    UpperCaseWords.Add(InputList[i]);
                }
                else
                {
                    MixedCaseWords.Add(InputList[i]);
                }
            }
            Console.WriteLine($"Lower-case: {string.Join(", ", LowerCaseWords)}");
            Console.WriteLine($"Mixed-case: {string.Join(", ", MixedCaseWords)}");
            Console.WriteLine($"Upper-case: {string.Join(", ", UpperCaseWords)}");
        }
    }
}
