using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___7.Count_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> InputNumbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            InputNumbers.Sort();
            int counter = 0;
            int PreviousValue = -1;
            for (int i = 0; i < InputNumbers.Count; i++)
            {
                int CurrentValue = InputNumbers[i];
                if (PreviousValue == -1)
                {
                    PreviousValue = CurrentValue;
                    counter = 1;
                }
                else if (i < InputNumbers.Count - 1)
                {
                    if (PreviousValue == CurrentValue)
                    {
                        counter++;
                    }
                    else
                    {
                        Console.WriteLine($"{PreviousValue} -> {counter}");
                        counter = 1;
                        PreviousValue = CurrentValue;
                    }
                }
                else
                {
                    if (PreviousValue == CurrentValue)
                    {
                        counter++;
                        Console.WriteLine($"{PreviousValue} -> {counter}");
                    }
                    else
                    {
                        Console.WriteLine($"{PreviousValue} -> {counter}");
                        counter = 1;
                        Console.WriteLine($"{CurrentValue} -> {counter}");
                    }
                }
            }
        }
    }
}
