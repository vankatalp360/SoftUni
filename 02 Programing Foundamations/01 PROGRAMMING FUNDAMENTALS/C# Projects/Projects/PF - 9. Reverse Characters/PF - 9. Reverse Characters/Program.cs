using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___9.Reverse_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            char First = char.Parse(Console.ReadLine());
            char Second = char.Parse(Console.ReadLine());
            char Third = char.Parse(Console.ReadLine());
            Console.WriteLine($"{Third}{Second}{First}");
        }
    }
}
