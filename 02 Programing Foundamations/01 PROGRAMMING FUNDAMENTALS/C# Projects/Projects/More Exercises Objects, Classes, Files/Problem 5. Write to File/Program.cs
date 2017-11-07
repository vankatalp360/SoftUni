using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_5.Write_to_File
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] punctuations = { '.', ',', '!', '?', ':' };
            string[] originalText = File.ReadAllLines("sample_text.txt");
            StringBuilder outInput = new StringBuilder();
            for (int i = 0; i < originalText.Length; i++)
            {
                char[] textWithoutPunctoation = originalText[i].ToCharArray().Where(x => !punctuations.Contains(x)).ToArray();
                outInput.Append(string.Join("",textWithoutPunctoation)).Append("\r\n");
            }
            File.WriteAllText("result_text.txt", outInput.ToString());
        }
    }
}
