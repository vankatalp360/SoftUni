using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___7.Count_Numbers_Rev2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> InputNumbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            InputNumbers.Sort();
            int counter = 0;
            if (InputNumbers.Count != 0)
            {
                int CurrentValue = InputNumbers[0];
                for (int i = 0; i < InputNumbers.Count; i++)
                {
                    if (CurrentValue == InputNumbers[i])
                    {
                        counter++;
                    }
                    else
                    {
                        Console.WriteLine($"{CurrentValue} -> {counter}");
                        CurrentValue = InputNumbers[i];
                        counter = 1;
                    }
                }
                Console.WriteLine($"{CurrentValue} -> {counter}");
            }
        }
    }
}
