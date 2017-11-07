using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Count_substring_occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine().ToLower();
            string patern = Console.ReadLine().ToLower();
            int counter = 0;
            int possition = 0;
            while (text.IndexOf(patern, possition) !=-1)
            {
                possition = text.IndexOf(patern, possition) +1;
                counter++;
            }
            Console.WriteLine(counter);
        }
    }
}
