using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_1.Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> names = new HashSet<string>();
            for(int i = 1; i <= n; i++)
            {
                names.Add(Console.ReadLine());
            }
            Console.WriteLine(string.Join("\r\n", names));
        }
    }
}
