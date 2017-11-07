using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Randomize_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split().ToArray();
            Random rnd = new Random();
            for(int i = 0; i<words.Length; i ++)
            {
                int randomNumber = rnd.Next(0, words.Length - 1);
                string temp = words[randomNumber];
                words[randomNumber] = words[i];
                words[i] = temp;
            }
            foreach(string word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
