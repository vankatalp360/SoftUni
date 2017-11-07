using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem_4___Cubic_s_Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string message = Console.ReadLine();
                if (message == "Over!") break;
                int messageLenght = int.Parse(Console.ReadLine());
                string pattern = @"^(\d+)([A-Za-z]{" + messageLenght + "})([^A-Za-z]*)$";
                Match matches = Regex.Match(message, pattern);
                if (matches.Success)
                {
                    string decryptedMassage = matches.Groups[2].Value;
                    string prefix = matches.Groups[1].Value;
                    string sufix = matches.Groups[3].Value;
                    List<int> indexes = new List<int>();
                    foreach (var i in prefix)
                    {
                        int digit = int.Parse(i.ToString());
                        indexes.Add(digit);
                    }
                    foreach (var i in sufix)
                    {
                        if (char.IsDigit(i))
                        {
                            int digit = int.Parse(i.ToString());
                            indexes.Add(digit);
                        }
                    }
                    List<char> letter = new List<char>();
                    foreach (int index in indexes)
                    {
                        if (index >= 0 && index < decryptedMassage.Length)
                        {
                            letter.Add(decryptedMassage[index]);
                        }
                        else
                        {
                            letter.Add(' ');
                        }
                    }
                    Console.WriteLine($"{decryptedMassage} == {string.Join("", letter)}");
                }
            }
        }
    }
}
