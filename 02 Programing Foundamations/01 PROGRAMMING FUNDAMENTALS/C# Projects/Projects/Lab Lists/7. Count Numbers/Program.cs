using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Count_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> InputNumbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            InputNumbers.Sort();
            if (InputNumbers.Count != 0)
            {
                int counter = 1;
                int currunt = InputNumbers[0];
                for (int i = 1; i < InputNumbers.Count; i++)
                {
                    if (currunt == InputNumbers[i]) counter++;
                    else
                    {
                        Console.WriteLine($"{currunt} -> {counter}");
                        currunt = InputNumbers[i];
                        counter = 1;
                    }
                }
                Console.WriteLine($"{currunt} -> {counter}");
            }
        }
    }
}
