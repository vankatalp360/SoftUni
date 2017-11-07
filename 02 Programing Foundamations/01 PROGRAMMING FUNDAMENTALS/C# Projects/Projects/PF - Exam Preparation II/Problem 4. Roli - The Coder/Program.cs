using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem_4.Roli___The_Coder
{
    class Program
    {
        static void Main(string[] args)
        {
            //string pattern = @"[#\ \t]+";
            Dictionary<string, List<string>> totalParticipantsInfo = new Dictionary<string, List<string>>();
            Dictionary<string, string> totalEvents = new Dictionary<string, string>();
            while (true)
            {
                string eventInfo = Console.ReadLine();
                if (eventInfo == "Time for Code") break;
                string[] currentEvent = eventInfo.Split(new char[] { ' ', '#' }, StringSplitOptions.RemoveEmptyEntries);
                string eventID = currentEvent[0];
                string eventName = currentEvent[1];
                List<string> currentParticipants = new List<string>();
                if (currentEvent.Length > 2)
                {
                   currentParticipants.AddRange(currentEvent.Skip(2).Take(currentEvent.Length - 2).ToList());
                }
                    
                if (!totalEvents.ContainsKey(eventID))
                {
                    totalEvents[eventID] = eventName;
                    totalParticipantsInfo[eventName] = currentParticipants;
                }
                else
                {
                    if (totalEvents[eventID]==eventName)
                    {
                        foreach (var participant in currentParticipants)
                        {
                            if (!totalParticipantsInfo[eventName].Contains(participant)) totalParticipantsInfo[eventName].Add(participant);
                        }
                    }
                }
            }
            foreach (var @event in totalParticipantsInfo.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{@event.Key} - {@event.Value.Count}");
                foreach (var participant in @event.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"{participant}");
                }
            }
        }
    }
}
