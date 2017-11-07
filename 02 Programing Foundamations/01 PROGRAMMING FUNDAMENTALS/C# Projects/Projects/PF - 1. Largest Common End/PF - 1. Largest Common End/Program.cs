using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___1.Largest_Common_End
{
    class Program
    {
        static void Main(string[] args)
        {
            string FirstLetter = Console.ReadLine();
            string SecondLetter = Console.ReadLine();
            string[] FirstLetters = FirstLetter.Split(' ');
            string[] SecondLetters = SecondLetter.Split(' ');                              
            int counterLeft = Counter(FirstLetters, SecondLetters);
             FirstLetter = Reverse(FirstLetter);
             SecondLetter = Reverse(SecondLetter);
            string[] ReversedFirstLetters = FirstLetter.Split(' ');
            string[] ReversedSecondLetters = SecondLetter.Split(' ');
            int counterRight = Counter(ReversedFirstLetters, ReversedSecondLetters); 
            if (counterLeft >= counterRight)
                Console.WriteLine(counterLeft);
            else Console.WriteLine(counterRight);
        }
        private static int Counter(string[] FirstLetters, string[] SecondLetters)
        {
            int counter = 0;
            for (int i = 0; i < Math.Min(FirstLetters.Length, SecondLetters.Length); i++)
            {
                if (FirstLetters[i] == SecondLetters[i])
                {
                    counter++;
                }
                else break;
            }
            return counter;
        }
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
