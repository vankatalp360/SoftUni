using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3_Largest_prime_factor
{
    class Program
    {
        static void Main(string[] args)
        {
            long n = 600851475143L; //this is a large prime number 
            long i = 2L;
            int test = 0;
            List<long> factors = new List<long>();
            while (n > 1)
            {
                while (n % i == 0)
                {
                    n /= i;
                    factors.Add(i);
                }

                i++;

                if (i * i > n && n > 1)
                {
                    factors.Add(n);
                    Console.WriteLine(n); ; //prints n if it's prime
                    test = 1;
                    break;
                }
            }

            if (test == 0)
                Console.WriteLine(i - 1); //prints n if it's the largest prime factor
            factors.Distinct();
            Console.WriteLine(string.Join(", ",factors));
        }

    }
}
