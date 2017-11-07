using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_6.Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int pupmsNumber = int.Parse(Console.ReadLine());
            Queue<int> sequence = new Queue<int>();
            for (int i = 1; i <= pupmsNumber; i++)
            {
                int[] pumpDetails = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int diff = pumpDetails[0] - pumpDetails[1];
                sequence.Enqueue(diff);
            }
            int sum = 0;
            int counter = 0;
            for (int k = 1; k <= pupmsNumber; k++)
            {
                int j = sequence.Dequeue();
                sequence.Enqueue(j);
                sum += j;
                if (sum < 0)    
                {
                    k = 0;
                    sum = 0;                    
                }
                counter++;
            }
            Console.WriteLine(counter%pupmsNumber);
        }
    }
}
