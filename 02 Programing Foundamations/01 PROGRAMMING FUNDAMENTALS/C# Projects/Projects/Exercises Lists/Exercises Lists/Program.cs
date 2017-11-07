using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            if (numbers.Count > 0)
            {
                int maxSequence = 0;
                int maxLength = 0;
                int currentLenght = 1;
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (i == 0)
                    {
                        maxSequence = numbers[0];
                        maxLength = 1;
                    }
                    else
                    {
                        if (numbers[i - 1] == numbers[i])
                        {
                            currentLenght++;
                        }
                        else
                        {
                            if (currentLenght > maxLength)
                            {
                                maxLength = currentLenght;
                                maxSequence = numbers[i - 1];
                            }
                            else
                                currentLenght = 1;
                        }
                        if (currentLenght > maxLength)
                        {
                            maxLength = currentLenght;
                            maxSequence = numbers[i - 1];
                        }
                    }
                }
                for (int i = 1; i <= maxLength; i++)
                {
                    if (i != maxLength) Console.Write(maxSequence + " ");
                    else Console.WriteLine(maxSequence);
                }
            }
        }
    }
}
