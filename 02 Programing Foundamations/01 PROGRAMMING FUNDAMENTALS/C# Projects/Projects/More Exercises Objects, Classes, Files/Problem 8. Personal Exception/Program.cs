using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_8.Personal_Exception
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    int number = int.Parse(Console.ReadLine());
                    if (number >= 0) Console.WriteLine(number);
                    else
                        throw (new Personal_Exception());
                }
                catch (Personal_Exception pe)
                {
                    Console.WriteLine(pe.Message);
                    break;
                }

            }
        }
    }

    
}
