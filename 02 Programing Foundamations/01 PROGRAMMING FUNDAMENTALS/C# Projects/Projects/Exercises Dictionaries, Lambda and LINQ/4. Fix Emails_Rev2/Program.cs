using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Fix_Emails_Rev2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> emailsBook = new Dictionary<string, string>();
            while (true)
            {
                string name = Console.ReadLine();
                if (name == "stop") break;
                string email = Console.ReadLine();
                string[] words = email.Split('.').ToArray();
                int lenght = words.Length - 1;
                if (words[lenght] == "us" || words[lenght] == "uk") continue;
                emailsBook[name] = email;
            }
            foreach (var person in emailsBook)
            {
                Console.WriteLine($"{person.Key} -> {person.Value}");
            }
        }
    }
}
