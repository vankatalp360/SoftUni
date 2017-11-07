using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3___Hornet_Assault
{
    class Program
    {
        static void Main(string[] args)
        {
            List<long> amountOfBees = Console.ReadLine().Split(' ').Select(long.Parse).ToList();
            List<long> hornetsPower = Console.ReadLine().Split(' ').Select(long.Parse).ToList();
            for (int i = 0; i < amountOfBees.Count; i++)
            {
                if (amountOfBees.Count == 0) break;
                if (hornetsPower.Count == 0) break;
                long sumHornetPower = hornetsPower.Sum();
                if (amountOfBees[i] < sumHornetPower)
                {
                    amountOfBees.RemoveAt(i);
                    i--;
                }
                else if (amountOfBees[i] == sumHornetPower)
                {
                    amountOfBees.RemoveAt(i);
                    i--;
                    hornetsPower.RemoveAt(0);
                }
                else
                {
                    amountOfBees[i] = amountOfBees[i] - sumHornetPower;
                    hornetsPower.RemoveAt(0);
                }
            }
            if (amountOfBees.Count!=0)
            {
                Console.WriteLine(string.Join(" ", amountOfBees));
            }
            else if (hornetsPower.Count!=0)
            {
                Console.WriteLine(string.Join(" ", hornetsPower));
            }
        }
    }
}
