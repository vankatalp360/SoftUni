using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___6.Triples_of_Latin_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            for (char i='a';i<='a'+N-1;i++)
            {
                for (char j = 'a'; j <= 'a' + N-1; j++)
                {
                    for (char k = 'a'; k <= 'a' + N-1; k++)
                    {
                        Console.WriteLine("{0}{1}{2}",i, j, k);
                    }
                }
            }
        }
    }
}
