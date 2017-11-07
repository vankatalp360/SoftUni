using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_11.Test_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int maxsum = int.Parse(Console.ReadLine());
            int sum = 0;
            int counter = 0;
            for (int i = first; i >= 1; i--)
            {
                for (int j = 1; j <= second; j++)
                {
                    counter++;
                    int result = i * j * 3;
                    sum += result;
                    if (sum >= maxsum)
                    {
                        Console.WriteLine($"{counter} combinations");
                        Console.WriteLine($"Sum: {sum} >= {maxsum}");
                        return;
                    }
                }
            }
            Console.WriteLine($"{counter} combinations");
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
