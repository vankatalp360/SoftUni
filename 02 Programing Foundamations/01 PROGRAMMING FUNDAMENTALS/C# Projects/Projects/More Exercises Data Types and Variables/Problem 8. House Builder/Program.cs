using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_8.House_Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            int integerNumber;
            sbyte sbyteNumber;
            string firstNumber = Console.ReadLine();
            string secondNumber = Console.ReadLine();
            try
            {
                 integerNumber = int.Parse(firstNumber);
                 sbyteNumber = sbyte.Parse(secondNumber);
            }
            catch
            {
                 sbyteNumber = sbyte.Parse(firstNumber);
                 integerNumber = int.Parse(secondNumber);
            }
            long Total = 4 * (long)sbyteNumber + 10 * (long)integerNumber;
            Console.WriteLine(Total);
        }
    }
}
