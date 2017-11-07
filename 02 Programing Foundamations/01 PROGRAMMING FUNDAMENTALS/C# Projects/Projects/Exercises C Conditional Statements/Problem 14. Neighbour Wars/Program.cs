using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_14.Neighbour_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            int PeshosDamage = int.Parse(Console.ReadLine());
            int GoshosDamage = int.Parse(Console.ReadLine());
            int PeshosBlood = 100;
            int GoshosBlood = 100;
            int counter = 1;
            int thirdCounter = 0;
            string Winner = null;
            while (true)
            {
                string AttackerName = "Pesho";
                string AttackName = "Roundhouse kick";
                string DefenderName = "Gosho";
                GoshosBlood -= PeshosDamage;

                if (GoshosBlood > 0)
                {
                    Console.WriteLine($"{AttackerName} used {AttackName} and reduced {DefenderName} to {GoshosBlood} health.");
                    counter++;
                    thirdCounter++;
                    if (thirdCounter == 3)
                    {
                        thirdCounter = 0;
                        PeshosBlood += 10;
                        GoshosBlood += 10;
                    }
                    PeshosBlood -= GoshosDamage;
                    if (PeshosBlood > 0)
                    {
                        AttackerName = "Gosho";
                        AttackName = "Thunderous fist";
                        DefenderName = "Pesho";
                        Console.WriteLine($"{AttackerName} used {AttackName} and reduced {DefenderName} to {PeshosBlood} health.");
                        counter++;
                        thirdCounter++;
                        if (thirdCounter == 3)
                        {
                            thirdCounter = 0;
                            PeshosBlood += 10;
                            GoshosBlood += 10;
                        }
                    }
                    else
                    {
                        Winner = "Gosho";
                        break;
                    }
                }
                else
                {
                    Winner = "Pesho";
                    break;
                }
            }
            Console.WriteLine($"{Winner} won in {counter}th round.");
        }
    }
}
