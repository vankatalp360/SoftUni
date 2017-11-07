using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___4.Variable_in_Hexadecimal_Format
{
    class Program
    {
        static void Main(string[] args)
        {
            string Number = Console.ReadLine();
            decimal TheNumber = Convert.ToInt32(Number, 16);
            Console.WriteLine(TheNumber);
        }
    }
}
