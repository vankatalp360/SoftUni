using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_9.Jump_Around
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            long totalSum = 0;
            int currentPoss = 0;
            while(true)
            {
                int currentValue = numbers[currentPoss];
                totalSum += currentValue;
                int currentStep = currentValue;
                if (currentPoss + currentStep<=numbers.Length)
                {
                    currentPoss = currentPoss + currentStep;
                }
                else
                {
                    if (currentPoss - currentStep >= 0)
                    {
                        currentPoss = currentPoss - currentStep;
                    }
                    else break;
                }
            }
            Console.WriteLine(totalSum);
        }
    }
}
