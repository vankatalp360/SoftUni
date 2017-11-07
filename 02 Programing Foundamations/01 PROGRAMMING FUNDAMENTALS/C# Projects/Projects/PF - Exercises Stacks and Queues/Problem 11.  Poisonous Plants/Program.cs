using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_11.Poisonous_Plants
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPlants = int.Parse(Console.ReadLine());
            Queue<long> plans = new Queue<long>(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).Take(numberOfPlants).ToArray());
            long counter = 0;

            while(true)
            {
                long lenght = plans.Count;
                long element = plans.Dequeue();
                plans.Enqueue(element);
                long currentCounter = 0;
                for (long k = 1; k < lenght;k++)
                {                    
                    long next = plans.Dequeue();
                    currentCounter++;
                    if (next<=element)
                    {
                        plans.Enqueue(next);
                        currentCounter--;                        
                    }
                    element = next;
                }
                if (currentCounter == 0)
                {
                    break;
                }
                else
                {
                    lenght = plans.Count;
                    counter++;
                    currentCounter = 0;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
