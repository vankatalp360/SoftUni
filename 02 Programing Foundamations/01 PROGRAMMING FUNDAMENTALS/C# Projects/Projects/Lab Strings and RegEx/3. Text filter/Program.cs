using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _3.Text_filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string keys = Console.ReadLine();
            string patternKeys = @"\,\s";
            string[] keysCollection = Regex.Split(keys, patternKeys);
            string text = Console.ReadLine();
            foreach (var key in keysCollection)
            {
                text = Regex.Replace(text, $@"({key})",
                                              new string('*', key.Length));
            }
            Console.WriteLine(text);
        }
    }
}

//string pattern = $@"({string.Join(")|(", keysCollection)})";