using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_5.Character_Stats
{
    class Program
    {
        static void Main(string[] args)
        {
            string Name = Console.ReadLine();
            int currentHealth = int.Parse(Console.ReadLine());
            int maximumHealth = int.Parse(Console.ReadLine());
            int currentEnergy = int.Parse(Console.ReadLine());
            int maximumEnergy = int.Parse(Console.ReadLine());
            Console.WriteLine($"Name: {Name}");
            string Health = null;
            for (int i = 1; i <= maximumHealth; i++)
            {
                if (i <= currentHealth) Health += '|';
                else Health += '.';
            }
            Console.WriteLine($"Health: |{Health }| ");
            string Energy = null;
            for (int i = 1; i <= maximumEnergy; i++)
            {
                if (i <= currentEnergy) Energy += '|';
                else Energy += '.';
            }
            Console.WriteLine($"Energy: |{Energy }| ");
        }
    }
}
