using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_13.Magic_Letter
{
    class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());
            char third = char.Parse(Console.ReadLine());
            
            for (char i =first;i<=second;i++)
            {
                if (i == third) continue;
                for (char j = first; j <= second; j++)
                {
                    if (j == third) continue;
                    for (char k = first; k <= second; k++)
                    {
                        if (k == third) continue;
                        if (k == second && j == second && i == second)
                        {
                            Console.WriteLine($"{i}{j}{k}"); 
                        }
                        else Console.Write($"{i}{j}{k} ");
                    }
                }
            }
        }
    }
}
