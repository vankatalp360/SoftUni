using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___13.Vowel_or_Digit
{
    class Program
    {
        static void Main(string[] args)
        {
            char Symbol = char.Parse(Console.ReadLine().ToLower());
            string Result = null;
            if (Symbol == 'a' || Symbol == 'e' || Symbol == 'i' || Symbol == 'u' || Symbol == 'o' || Symbol == 'y') Result = "vowel";
            else if (Symbol >= 48 && Symbol <= 57) Result = "digit";
            else Result = "other";
            Console.WriteLine(Result);
        }
    }
}
