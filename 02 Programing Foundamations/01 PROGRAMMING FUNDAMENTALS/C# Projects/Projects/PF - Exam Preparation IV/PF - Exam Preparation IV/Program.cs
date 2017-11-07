using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___Exam_Preparation_IV
{
    class Program
    {
        static void Main(string[] args)
        {
            double Cash = double.Parse(Console.ReadLine());
            int NumberOfGuess = int.Parse(Console.ReadLine());
            double BananasPrice = double.Parse(Console.ReadLine());
            double EggsPrice = double.Parse(Console.ReadLine());
            double BerriesPrice = double.Parse(Console.ReadLine());

            int NumberOfPorsion;
            if (NumberOfGuess % 6 == 0) NumberOfPorsion = NumberOfGuess / 6; else NumberOfPorsion = NumberOfGuess / 6 + 1;

            double TotalCost = NumberOfPorsion * (2 * BananasPrice + 4 * EggsPrice + 0.2d * BerriesPrice);
            if (Cash >= TotalCost)
                Console.WriteLine($"Ivancho has enough money - it would cost {TotalCost:f2}lv.");
            else
                Console.WriteLine($"Ivancho will have to withdraw money - he will need {(TotalCost - Cash):F2}lv more.");
        }
    }
}
