using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace RageQuit
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            HashSet<char> unique = new HashSet<char>();
            List<int> multiplayers = new List<int>();
            List<string> msgs = new List<string>();
            Regex numbs = new Regex(@"\d+");
            var matches = numbs.Matches(message);
            foreach (Match numb in matches)
            {
                multiplayers.Add(int.Parse(numb.ToString()));
            }
            string output = string.Empty;
            string curMessage = string.Empty;
            for (int i = 0; i < message.Length; i++)
            {
                if (message[i] < '0' || message[i] > '9')
                {

                    curMessage = curMessage + message[i];
                }
                if (message[i] >= '0' && message[i] <= '9')
                {
                    if (curMessage != "")
                    {
                        msgs.Add(curMessage.ToUpper());

                    }
                    curMessage = string.Empty;
                }

            }
            int k = 0;
            for (int b = 0; b < msgs.Count; b++)
            {
                if (multiplayers[k] > 0)
                {
                    for (int i = 0; i < msgs[b].Length; i++)
                    {
                        unique.Add(char.ToUpper(msgs[b][i]));
                    }
                }
                k++;
            }
            Console.WriteLine("Unique symbols used: " + unique.Count);
            k = 0;
            foreach (var item in msgs)
            {
                for (int i = 0; i < multiplayers[k]; i++)
                {
                    Console.Write(item);
                }
                k++;
            }
        }
    }
}