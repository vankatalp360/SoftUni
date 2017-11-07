using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___5.Boolean_Variable
{
    class Program
    {
        static void Main(string[] args)
        {
            string BooleanString = Console.ReadLine();
            bool InstructionBoolean = Convert.ToBoolean(BooleanString);
            if (InstructionBoolean) Console.WriteLine("Yes"); else Console.WriteLine("No");
        }
    }
}
