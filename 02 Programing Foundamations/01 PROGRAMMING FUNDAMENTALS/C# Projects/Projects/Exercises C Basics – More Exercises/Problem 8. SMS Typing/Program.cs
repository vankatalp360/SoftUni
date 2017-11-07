using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_8.SMS_Typing
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfchar = int.Parse(Console.ReadLine());
            string letter = null;
            for (int i = 1; i <= numberOfchar; i++)
            {
                int number = int.Parse(Console.ReadLine());
                int digitLenght;
                if (number / 1000 > 0) digitLenght = 4;
                else if (number / 100 > 0) digitLenght = 3;
                else if (number / 10 > 0) digitLenght = 2;
                else digitLenght = 1;
                if (number != 1)
                {
                    if (number == 0)
                    {
                        letter += ' ';
                    }
                    else
                    {
                        int mainDigit = number % 10;
                        int offset = (mainDigit - 2) * 3;
                        if (mainDigit == 8 || mainDigit == 9) offset++;
                        int index = (offset + digitLenght - 1) + 97;
                        char parameter = (char)index;
                        letter += parameter;
                    }
                }
            }
            Console.WriteLine(letter);
        }
    }
}
