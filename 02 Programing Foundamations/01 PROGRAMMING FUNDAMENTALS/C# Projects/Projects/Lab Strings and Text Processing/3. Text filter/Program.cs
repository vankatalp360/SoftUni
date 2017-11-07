using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Text_filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            string text = Console.ReadLine();
            foreach (var word in bannedWords)
            {
                string replaceWord = "";
                for(int i =0; i < word.Length;i++)
                {
                    replaceWord+="*";
                }
                text = text.Replace(word, replaceWord);
            }
            Console.WriteLine(text);
        }
    }
}
