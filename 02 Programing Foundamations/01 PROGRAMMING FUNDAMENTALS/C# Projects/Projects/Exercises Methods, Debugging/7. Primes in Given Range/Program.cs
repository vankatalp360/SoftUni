using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Prime_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            int startNumber = int.Parse(Console.ReadLine());
            int endNumber = int.Parse(Console.ReadLine());
            if (startNumber < 0) startNumber = 0;
            List<int> numbers = new List<int>();
            if (startNumber>=2||endNumber>=2)
            {
                numbers = FindPrimesInRange( startNumber,  endNumber);
            }
            Console.WriteLine(string.Join(", ",numbers));
        }
        private static List<int> FindPrimesInRange(int startNumber, int endNumber)
        {
            List<int> numbers = new List<int>();
            for (int i = startNumber; i<= endNumber; i++)
            {
                if (IsPrime(i)) numbers.Add(i);
            }
            return numbers;
        }
        private static bool IsPrime(int number)
        {
            bool result = false;
            if (number >= 2)
            {
                result = true;
                for (int i = 2; i <= Math.Sqrt(number); i++)
                {
                    if (number % i == 0)
                    {
                        result = false;
                        break;
                    }
                }
            }

            return result;
        }
    }
}
