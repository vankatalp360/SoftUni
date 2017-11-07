using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___7.Exchange_Variable_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            int First = 5;
            int Second = 10;
            Console.WriteLine($"Before:\na = {First}\nb = {Second}");
            int Temp = First;
            First = Second;
            Second = Temp;
            Console.WriteLine($"After:\na = {First}\nb = {Second}");
        }
    }
}
