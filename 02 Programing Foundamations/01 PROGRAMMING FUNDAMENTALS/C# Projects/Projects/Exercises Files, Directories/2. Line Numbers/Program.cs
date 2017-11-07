using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] originalText = File.ReadAllLines("Input.txt");
            StringBuilder outInput = new StringBuilder();
            for (int i = 0; i < originalText.Length; i++)
            {
                outInput.Append($"{i + 1}. ").Append(originalText[i]).Append("\r\n");
            }
            File.WriteAllText("text.txt", outInput.ToString());
        }
    }
}
