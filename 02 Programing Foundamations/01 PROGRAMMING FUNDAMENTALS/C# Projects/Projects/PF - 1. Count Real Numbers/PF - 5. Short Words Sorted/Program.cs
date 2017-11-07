using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___5.Short_Words_Sorted
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] exeptions = { ',', ':', ';', '(', ')', '[', ']', '"', '\'', '\\', '/', '!', '?', ' ' };
            string[] letters = Console.ReadLine().ToLower().Split(exeptions, StringSplitOptions.RemoveEmptyEntries).Where(x => x.Length < 5).OrderBy(x => x).Distinct().ToArray();
            Console.WriteLine(string.Join(", ", letters));
        }
    }
}
