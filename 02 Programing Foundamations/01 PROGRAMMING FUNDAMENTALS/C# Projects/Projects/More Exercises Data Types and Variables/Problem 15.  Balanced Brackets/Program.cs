using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_15.Balanced_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            string result = null;
            for (int i =1; i <=numberOfLines;i++)
            {
                string word = Console.ReadLine();
                if (word=="(")
                {
                    if (result == "(") break;
                    result=word;
                }
                else if (word == ")"&&result== "(")
                {
                    result = word;
                }
            }
            if (result == ")") Console.WriteLine("BALANCED"); else Console.WriteLine("UNBALANCED");
        }
    }
}
