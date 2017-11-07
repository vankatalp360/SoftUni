using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___14.Integer_to_Hex_and_Binary
{
    class Program
    {
        static void Main(string[] args)
        {
            int Number = int.Parse(Console.ReadLine());
            int[] Bases = { 16, 2 };
            foreach (int basevalue in Bases)
            {
                string Letter = Convert.ToString(Number, basevalue).ToUpper();
                Console.WriteLine(Letter);
            }
        }
    }
}
