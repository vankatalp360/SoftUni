using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises_Files__Directories
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] textInput = File.ReadAllLines("Input.txt");
            StringBuilder outInput = new StringBuilder();
            for (int i = 0; i < textInput.Length; i++)
            {
                if (i % 2 == 1) outInput.Append(textInput[i]).Append("\r\n");
            }
            File.WriteAllText("text.txt", outInput.ToString());
        }
    }
}
