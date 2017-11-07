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
            List<long> amountOfbees = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
            List<long> hornetsPower = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
            BeesAndHornetsFight(amountOfbees, hornetsPower);
            PrintResult(amountOfbees, hornetsPower);
        }

        private static void BeesAndHornetsFight(List<long> amountOfbees, List<long> hornetsPower)
        {
            for (int i = 0; i < amountOfbees.Count; i++)
            {
                if (hornetsPower.Count == 0) break;
                long sumHornetsPower = hornetsPower.Sum();
                if (amountOfbees[i] < sumHornetsPower)
                {
                    amountOfbees.RemoveAt(i);
                    i--;
                }
                else if (amountOfbees[i] == sumHornetsPower)
                {
                    amountOfbees.RemoveAt(i);
                    hornetsPower.RemoveAt(0);
                    i--;
                }
                else
                {
                    amountOfbees[i] = amountOfbees[i] - sumHornetsPower;
                    hornetsPower.RemoveAt(0);
                }
            }
        }

        private static void PrintResult(List<long> amountOfbees, List<long> hornetsPower)
        {
            if (amountOfbees.Count != 0)
            {
                Console.WriteLine(string.Join(" ", amountOfbees));
            }
            else if (hornetsPower.Count != 0)
            {
                Console.WriteLine(string.Join(" ", hornetsPower));
            }
        }
    }
}
