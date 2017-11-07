using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___2.Min_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            int LastNumber = int.Parse(Console.ReadLine());
            for (int i = 1; i<3;i++)
            {
                int CurrentNumber = int.Parse(Console.ReadLine());
                int CurrentMaxNumber = GetMaxNumber(LastNumber, CurrentNumber);
                LastNumber = CurrentMaxNumber;
            }
            Console.WriteLine(LastNumber);
        }
        static int GetMaxNumber(int A, int B)
        {
            if (A >= B) return A;
            else return B;
        }
    }
}
