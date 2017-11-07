using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().ToLower(). Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            Dictionary<string, int> sequenceOfWords = new Dictionary<string, int>();
            foreach(string word in words)
            {
                if (sequenceOfWords.ContainsKey(word)) sequenceOfWords[word]++;
                else sequenceOfWords[word] = 1;
            }
            List<string> result = new List<string>(words.Count);
            foreach (var pair in sequenceOfWords)
            {
                if (pair.Value % 2 == 1) result.Add(pair.Key);
            }
            Console.WriteLine(string.Join(", ",result));
        }
    }
}
