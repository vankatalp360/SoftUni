using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___13.Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            BigInteger Factoriel = CalculateFactoriel(N);
            int counter = CountZeros(Factoriel);
            Console.WriteLine(counter);
        }
        private static BigInteger CalculateFactoriel(int TopNumber)
        {
            BigInteger Factoriel = 1;
            for (int i = 1; i <= TopNumber; i++)
            {
                Factoriel = Factoriel * i;
            }
            return Factoriel;
        }
        private static int CountZeros(BigInteger Number)
        {
            int Result = 0;
            while (Number != 0)
            {
                BigInteger LastCharacter = Number % 10;
                if (LastCharacter == 0) Result++;
                else break;
                Number = (Number - Number % 10) / 10;
            }
            return Result;
        }
    }
}
