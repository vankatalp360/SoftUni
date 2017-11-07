using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_7.Fix_emails
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> EmailBook = new Dictionary<string, string>();
            while (true)
            {
                string Name = Console.ReadLine();
                if (Name == "stop") break;
                string Mail = Console.ReadLine();
                if (Mail.LastIndexOf("us") != Mail.Length - 2 && Mail.LastIndexOf("uk") != Mail.Length - 2)
                {
                    EmailBook[Name] = Mail;
                }
            }
            foreach (var pair in EmailBook)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }
    }
}
