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
            string privateMassagePattern = @"^(?<firstQuery>\d+)(\ \<\-\>\ )(?<secondQuery>[0-9\/A-Za-z]+)$";
            string broadcastMassagePattern = @"^(?<firstQuery>[^0-9]+)(\ \<\-\>\ )(?<secondQuery>[A-Za-z\/0-9]+)$";
            Dictionary<string, List<string>> messages = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> broadcasts = new Dictionary<string, List<string>>();
            while (true)
            {
                string text = Console.ReadLine();
                if (text == "Hornet is Green") break;
                Match privateMassage = Regex.Match(text, privateMassagePattern);
                if (privateMassage.Success)
                {
                    string recipientsCode = string.Join("", privateMassage.Groups["firstQuery"].Value.ToCharArray().Reverse());
                    string message = privateMassage.Groups["secondQuery"].Value;
                    if (!messages.ContainsKey(recipientsCode))
                    {
                        messages[recipientsCode] = new List<string>();
                    }
                    messages[recipientsCode].Add(message);
                }
                Match broadcastsMassage = Regex.Match(text, broadcastMassagePattern);
                if (broadcastsMassage.Success)
                {
                    string message = broadcastsMassage.Groups["firstQuery"].Value;
                    char[] frequencyChars = broadcastsMassage.Groups["secondQuery"].Value.ToCharArray();
                    for(int i =0; i <frequencyChars.Length;i++)
                    {
                        if (char.IsLower(frequencyChars[i])) frequencyChars[i] = (char)(frequencyChars[i] - (97 - 65));
                        else if (char.IsUpper(frequencyChars[i])) frequencyChars[i] = (char)(frequencyChars[i] + (97 - 65));
                    }
                    string frequency = string.Join("", frequencyChars);
                    if (!broadcasts.ContainsKey(frequency))
                    {
                        broadcasts[frequency] = new List<string>();
                    }
                    broadcasts[frequency].Add(message);
                }
            }
            Console.WriteLine("Broadcasts:");
            if (broadcasts.Count!=0)
            {
                foreach(var boradcast in broadcasts)
                {
                    foreach(var frequency in boradcast.Value)
                    {
                        Console.WriteLine($"{boradcast.Key} -> {frequency}");
                    }
                }
            }
            else
            {
                Console.WriteLine("None");
            }
            Console.WriteLine("Messages:");
            if (messages.Count != 0)
            {
                foreach (var message in messages)
                {
                    foreach (var recipientsCode in message.Value)
                    {
                        Console.WriteLine($"{message.Key} -> {recipientsCode}");
                    }
                }
            }
            else
            {
                Console.WriteLine("None");
            }
        }
    }
}
