using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Email_Me
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();
            string[] emailExtracts = email.Split('@').ToArray();
            int leftSumChars = 0;
            for(int i =0; i <emailExtracts[0].Length;i++)
            {
                leftSumChars += emailExtracts[0][i];
            }
            int rightSumChars = 0;
            for (int i = 0; i < emailExtracts[1].Length; i++)
            {
                rightSumChars += emailExtracts[1][i];
            }
            if (leftSumChars-rightSumChars>=0)
            {
                Console.WriteLine($"Call her!");
            }
            else
            {
                Console.WriteLine($"She is not the one.");
            }
        }
    }
}
