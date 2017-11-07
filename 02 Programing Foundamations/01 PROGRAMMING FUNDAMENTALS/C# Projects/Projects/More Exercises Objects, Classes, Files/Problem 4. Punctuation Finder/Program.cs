using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_4.Punctuation_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] punctuations = { '.', ',', '!', '?', ':' };
            char[] textInput = File.ReadAllText("sample_text.txt").ToCharArray();
            char[] punctuationMarks = textInput.Where(x => punctuations.Contains(x)).ToArray();
            Console.WriteLine(string.Join(", ", punctuationMarks));
            if (!File.Exists("result_text.txt"))
                File.Create("result_text.txt");
            File.WriteAllText("result_text.txt", string.Join(", ", punctuationMarks));
        }
    }
}

