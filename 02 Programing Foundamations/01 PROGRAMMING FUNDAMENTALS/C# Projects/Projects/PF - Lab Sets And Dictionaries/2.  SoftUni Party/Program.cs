using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _2.SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> VIPguests = new HashSet<string>();
            HashSet<string> commonGuests = new HashSet<string>();
            ReadGuestsList(VIPguests, commonGuests);
            FindWhoGuestsComeOnParty(VIPguests, commonGuests);
            PrintResult(VIPguests, commonGuests);
        }

        private static void FindWhoGuestsComeOnParty(HashSet<string> VIPguests, HashSet<string> commonGuests)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END") break;
                VIPguests.Remove(input);
                commonGuests.Remove(input);
            }
        }

        private static void ReadGuestsList(HashSet<string> VIPguests, HashSet<string> commonGuests)
        {
            string patternVIPguests = @"\d.{7}";
            Regex regex = new Regex(patternVIPguests);

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "PARTY") break;
                if (input.Length == 8)
                {
                    Match match = regex.Match(input);
                    if (match.Success)
                    {
                        VIPguests.Add(input);
                    }
                    else
                    {
                        commonGuests.Add(input);
                    }
                }
            }
        }

        private static void PrintResult(HashSet<string> VIPguests, HashSet<string> commonGuests)
        {
            int counter = VIPguests.Count + commonGuests.Count;
            Console.WriteLine(counter);
            if (counter != 0)
            {
                if (VIPguests.Count != 0)
                {
                    foreach (string VIPguest in VIPguests.OrderBy(x => x))
                    {
                        Console.WriteLine(VIPguest);
                    }
                }
                if (commonGuests.Count != 0)
                {
                    foreach (string commonGuest in commonGuests.OrderBy(x => x))
                    {
                        Console.WriteLine(commonGuest);
                    }
                }
            }
        }
    }
}
