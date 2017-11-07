using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem_4___Winning_Ticket
{
    class Program
    {
        static void Main(string[] args)
        {
            string ticketsPattern = @"\ *\,\ +";
            string[] tickets = Regex.Split(Console.ReadLine(), ticketsPattern);
            string pattern = @"[@]{6,}|[#]{6,}|[$]{6,}|[\^]{6,}";
            foreach (string ticket in tickets)
            {
                if (ticket.Length == 20)
                {
                    string leftHalf = ticket.Substring(0, ticket.Length / 2);
                    string rightHalf = ticket.Substring(ticket.Length / 2);
                    Match leftMatch = Regex.Match(leftHalf, pattern);
                    Match rightMatch = Regex.Match(rightHalf, pattern);
                    if (leftMatch.Length >= 6 && rightMatch.Length >= 6 && leftMatch.Groups[0].Value[0] == rightMatch.Groups[0].Value[0])
                    {
                        if (leftMatch.Length == 10 && rightMatch.Length == 10)
                        {
                            Console.WriteLine($"ticket \"{ticket}\" - {leftMatch.Length}{leftMatch.Groups[0].Value[0]} Jackpot!");
                        }
                        else
                        {
                            int number = Math.Min(leftMatch.Length, rightMatch.Length);
                            char letter;
                            if (number == leftMatch.Length)
                            {
                                letter = leftMatch.Groups[0].Value[0];
                            }
                            else
                            {
                                letter = rightMatch.Groups[0].Value[0];
                            }
                            Console.WriteLine($"ticket \"{ticket}\" - {number}{letter}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - no match");
                    }
                }
                else
                {
                    Console.WriteLine($"invalid ticket");
                }
            }
        }
    }
}
