using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_6.DNA_Sequences
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = int.Parse(Console.ReadLine());
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    for (int k = 1; k <= 4; k++)
                    {
                        char first = DefinceChar(i);
                        char second = DefinceChar(j);
                        char third = DefinceChar(k);
                        char enfold;
                        if (i + j + k >= sum) enfold = 'O'; else enfold = 'X';
                        if (k == 4)
                        {
                            Console.WriteLine($"{enfold}{first}{second}{third}{enfold}");
                        }
                        else
                            Console.Write($"{enfold}{first}{second}{third}{enfold} ");
                    }
                }
            }
        }
        private static char DefinceChar(int N)
        {
            switch (N)
            {
                case 1:
                    return 'A';
                case 2:
                    return 'C';
                case 3:
                    return 'G';
                default:
                    return 'T';
            }
        }
    }
}
