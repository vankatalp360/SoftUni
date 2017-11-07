using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Merge_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] linesInput1 = File.ReadAllLines("FileOne.txt");
            string[] linesInput2 = File.ReadAllLines("FileTwo.txt");
            int i = Math.Max(linesInput1.Length, linesInput2.Length);
            if (!File.Exists("Output.txt")) File.Create("Output.txt");
            else File.WriteAllText("Output.txt", "");
            for (int j = 0; j < i; j++)
            {
                if (j < linesInput1.Length)
                {
                    File.AppendAllText("Output.txt", linesInput1[j]);
                    File.AppendAllText("Output.txt", "\r\n");
                }
                if (j < linesInput2.Length)
                {
                    File.AppendAllText("Output.txt", linesInput2[j]);
                    File.AppendAllText("Output.txt", "\r\n");
                }
            }
        }
    }
}
