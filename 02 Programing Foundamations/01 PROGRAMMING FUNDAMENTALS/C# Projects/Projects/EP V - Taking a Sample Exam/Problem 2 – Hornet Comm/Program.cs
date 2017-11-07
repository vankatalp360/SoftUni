using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem_2___Hornet_Comm
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string[]> messages = new List<string[]>();
            List<string[]> broadcasts = new List<string[]>();
            string privateMessagePattern = @"^(\d*)\s+<->\s+([A-Za-z\/\d]*)$";
            string broadcastMessagePattern = @"^([^\d]*)\s+<->\s+([A-Za-z\/\d]*)$";
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Hornet is Green") break;
                Match privateMessage = Regex.Match(input, privateMessagePattern);
                Match broadcastMessage = Regex.Match(input, broadcastMessagePattern);
                if (privateMessage.Success)
                {
                    AddNewMessageInListStorageData(messages, privateMessage);
                }
                else if (broadcastMessage.Success)
                {
                    AddNewBroadCastInListStorageData(broadcasts, broadcastMessage);
                }
            }
            PrintResult(messages, broadcasts);
        }

        private static void PrintResult(List<string[]> messages, List<string[]> broadcasts)
        {
            Console.WriteLine("Broadcasts:");
            PrintListStorageData(broadcasts);
            Console.WriteLine("Messages:");
            PrintListStorageData(messages);
        }

        private static void AddNewMessageInListStorageData(List<string[]> messages, Match privateMessage)
        {
            string recipientsCode = string.Join("", privateMessage.Groups[1].Value.Reverse());
            string message = privateMessage.Groups[2].Value;
            messages.Add(new string[] { recipientsCode, message });
        }

        private static void AddNewBroadCastInListStorageData(List<string[]> broadcasts, Match broadcastMessage)
        {
            const int l = 'A' - 'a';
            string message = broadcastMessage.Groups[1].Value;
            char[] frequency = broadcastMessage.Groups[2].Value.ToCharArray();
            for (int i = 0; i < frequency.Length; i++)
            {
                if (char.IsLower(frequency[i])) frequency[i] = (char)(frequency[i] + l);
                else if (char.IsUpper(frequency[i])) frequency[i] = (char)(frequency[i] - l);
            }
            broadcasts.Add(new string[] { string.Join("", frequency), message });
        }

        private static void PrintListStorageData(List<string[]> arr)
        {
            if (arr.Count != 0)
            {
                foreach (var message in arr)
                {
                    Console.WriteLine($"{message[0]} -> {message[1]}");
                }
            }
            else
            {
                Console.WriteLine("None");
            }
        }
    }
}
