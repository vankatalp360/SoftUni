using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___9.Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int LenghtOfArray = int.Parse(Console.ReadLine());
            for (int ch = 1; ch <= LenghtOfArray; ch++)
            {
                int SumOfChars = 0;
                int DigCh = ch;
                while (DigCh > 0)
                {
                    SumOfChars += DigCh % 10;
                    DigCh = DigCh / 10;
                }
                Console.WriteLine("{0} -> {1}", ch,(SumOfChars == 5 || SumOfChars == 7 || SumOfChars == 11));
            }
        }
    }
}
