using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = File.ReadAllText("words.txt").Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.ToLower()).ToArray();
            string[] wordsFromText = File.ReadAllText("text.txt").Split(new[] { '\n', '\r', ' ', '.', ',', '!', '?', '-' , '…' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.ToLower()).ToArray();
            Dictionary<string, int> wordsCounters = new Dictionary<string, int>();
            foreach (var word in words)
            {
                int counter = 0;
                foreach (var text in wordsFromText)
                {
                    if (word == text) counter++;
                }
                if (!wordsCounters.ContainsKey(word))
                {
                    wordsCounters[word] = counter;
                }
            }
            if (!File.Exists("result.txt"))
            {
                File.Create("result.txt");
            }
            else
                File.WriteAllText("result.txt", "");
            foreach (var pair in wordsCounters.OrderByDescending(x => x.Value))
            {
                string text = $"{pair.Key} - {pair.Value}\r\n".ToString();
                File.AppendAllText("result.txt", text);
            }
        }
    }
}
