using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.User_Logs_Rev2
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, int>> userLogs = new SortedDictionary<string, Dictionary<string, int>>();
            while (true)
            {
                string[] letters = Console.ReadLine().Split(new char[] { '=', ' ' }).ToArray();
                if (letters[0] == "end") break;
                DefineTheUserLog(userLogs, letters);
            }
            PrintResult(userLogs);
        }

        private static void PrintResult(SortedDictionary<string, Dictionary<string, int>> userLogs)
        {
            foreach (var pair in userLogs)
            {
                Console.WriteLine($"{pair.Key}: ");
                Console.WriteLine("{0}.", string.Join(", ", pair.Value.Select(x => $"{x.Key} => {x.Value}")));
            }
        }

        private static void DefineTheUserLog(SortedDictionary<string, Dictionary<string, int>> userLogs, string[] letters)
        {
            string ip = letters[1];
            string user = letters[5];
            if (!userLogs.ContainsKey(user))
            {
                userLogs[user] = new Dictionary<string, int>() { { ip, 1 } };
            }
            else
            {
                if (userLogs[user].ContainsKey(ip))
                    userLogs[user][ip] += 1;
                else
                    userLogs[user][ip] = 1;
            }
        }
    }
}
