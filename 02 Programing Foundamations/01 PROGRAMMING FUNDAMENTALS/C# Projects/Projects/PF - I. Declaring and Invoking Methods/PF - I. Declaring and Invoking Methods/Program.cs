using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Declaring_and_Invoking_Methods
{
    class Declaring_and_Invoking_Methods
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            PrintReceipt();
        }
        private static void PrintReceipt()
        {

            PrintHeader();
            PrintBody();
            PrintFooter();
        }
        private static void PrintHeader()
        {
            Console.WriteLine("CASH RECEIPT");
            Console.WriteLine("------------------------------");
        }
        private static void PrintBody()
        {
            Console.WriteLine("Charged to____________________");
            Console.WriteLine("Received by___________________");
        }
        private static void PrintFooter()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("\u00A9 SoftUni");
        }
    }
}