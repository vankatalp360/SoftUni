using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_14.Boat_Simulator
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstBoatChar = char.Parse(Console.ReadLine());
            char secondBoatChar = char.Parse(Console.ReadLine());
            int numberOfLines = int.Parse(Console.ReadLine());
            int firstBoatTiles = 0;
            int secondBoatTiles = 0;
            for (int i = 1; i <= numberOfLines; i++)
            {
                string letter = Console.ReadLine();
                if (letter != "UPGRADE")
                {
                    if (i % 2 == 1)
                    {
                        firstBoatTiles += letter.Length;
                        if (firstBoatTiles >= 50) break;
                    }
                    else
                    {
                        secondBoatTiles += letter.Length;
                        if (secondBoatTiles >= 50) break;
                    }
                }
                else
                {
                    firstBoatChar = (char)(firstBoatChar + 3);
                    secondBoatChar = (char)(secondBoatChar + 3);
                }
            }
            if (firstBoatTiles >= secondBoatTiles) Console.WriteLine(firstBoatChar);
            else Console.WriteLine(secondBoatChar);
        }
    }
}
