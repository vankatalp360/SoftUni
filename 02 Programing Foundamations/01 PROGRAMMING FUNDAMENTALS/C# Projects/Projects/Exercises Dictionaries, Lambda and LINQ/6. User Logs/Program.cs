using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.User_Logs
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] separator = new char[] { '=', ' ' };
            SortedDictionary<string, Dictionary<string, int>> UsersIPsAndMessages = new SortedDictionary<string, Dictionary<string, int>>();
            while (true)
            {
                string[] currentuser = Console.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (currentuser[0].ToUpper() == "END") break;
                else
                {
                    if (UsersIPsAndMessages.ContainsKey(currentuser[5]))
                    {
                        Dictionary<string, int> CurrentUserIPs = UsersIPsAndMessages[currentuser[5]];
                        if (CurrentUserIPs.ContainsKey(currentuser[1]))
                        {
                            CurrentUserIPs[currentuser[1]]++;
                        }
                        else CurrentUserIPs[currentuser[1]] = 1;
                    }
                    else
                    {
                        Dictionary<string, int> UserNewIP = new Dictionary<string, int>();
                        UserNewIP[currentuser[1]] = 1;
                        UsersIPsAndMessages.Add(currentuser[5], UserNewIP);
                    }
                }
            }
            foreach (var pair in UsersIPsAndMessages)
            {
                Console.WriteLine($"{pair.Key}: ");
                int count = pair.Value.Count;
                int counter = 1;
                foreach (var value in pair.Value)
                {
                    if (counter!=count) Console.Write($"{value.Key} => {value.Value}, ");
                    else Console.WriteLine($"{value.Key} => {value.Value}.");
                    counter++;
                }
            }
        }
    }
}

