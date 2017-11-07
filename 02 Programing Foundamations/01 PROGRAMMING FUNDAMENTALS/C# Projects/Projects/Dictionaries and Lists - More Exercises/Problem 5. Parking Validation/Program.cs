using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication4
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands = int.Parse(Console.ReadLine());
            Dictionary<string, string> usersLog = new Dictionary<string, string>();
            for (int i = 1; i <= numberOfCommands; i++)
            {
                string[] input = Console.ReadLine().Split(' ').ToArray();
                switch (input[0])
                {
                    case "register":
                        RegisterManipulator(usersLog, input[1], input[2]);
                        break;
                    case "unregister":
                        UnregisterManipulator(usersLog, input[1]);
                        break;
                    default:
                        break;
                }
            }
            foreach (var pair in usersLog)
            {
                Console.WriteLine($"{pair.Key} => {pair.Value}");
            }
        }

        private static void RegisterManipulator(Dictionary<string, string> usersLog, string username, string licensePlateNumber)
        {
            if (usersLog.ContainsKey(username))
            {
                Console.WriteLine($"ERROR: already registered with plate number {usersLog[username]}");
            }
            else
            {
                if (!ValidationLicense(licensePlateNumber.ToCharArray()))
                {
                    Console.WriteLine($"ERROR: invalid license plate {licensePlateNumber}");
                }
                else
                {
                    if (usersLog.ContainsValue(licensePlateNumber))
                    {
                        if (!usersLog.ContainsKey(username))
                        {
                            Console.WriteLine($"ERROR: license plate {licensePlateNumber} is busy");
                        }
                        else
                        if (usersLog[username] != licensePlateNumber)
                        {
                            Console.WriteLine($"ERROR: license plate {licensePlateNumber} is busy");
                        }
                    }
                    else
                    {
                        usersLog[username] = licensePlateNumber;
                        Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
                    }
                }
            }
        }
        private static bool ValidationLicense(char[] licensePlateNumber)
        {
            if (licensePlateNumber.Length != 8) return false;
            char[] first = licensePlateNumber.Take(2).ToArray();
            if (!first.All(x => char.IsUpper(x))) return false;
            char[] last = licensePlateNumber.Skip(licensePlateNumber.Length - 2).Take(2).ToArray();
            if (!last.All(x => char.IsUpper(x))) return false;
            char[] middle = licensePlateNumber.Skip(2).Take(4).ToArray();
            if (!middle.All(x => x >= 48 && x <= 57)) return false;
            return true;
        }
        private static void UnregisterManipulator(Dictionary<string, string> usersLog, string username)
        {
            if (!usersLog.ContainsKey(username))
            {
                Console.WriteLine($"ERROR: user {username} not found");
            }
            else
            {
                Console.WriteLine($"user {username} unregistered successfully");
                usersLog.Remove(username);
            }
        }
    }
}
