using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Game_of_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfPlayers = int.Parse(Console.ReadLine());
            string playerName = null;
            int maxScore = int.MinValue;
            for(int i  = 1; i <=countOfPlayers;i++)
            {
                string currentPlayerName = Console.ReadLine();
                int currentPlayerScore = int.Parse(Console.ReadLine());

                for (int j = 0; j < currentPlayerName.Length;j++)
                {
                    if (currentPlayerName[j]%2==0)
                    {
                        currentPlayerScore += currentPlayerName[j];
                    }
                    else
                    {
                        currentPlayerScore -= currentPlayerName[j];
                    }
                   
                }
                
                if (maxScore<currentPlayerScore)
                {
                    maxScore = currentPlayerScore;
                    playerName = currentPlayerName;
                }
            }
            Console.WriteLine($"The winner is {playerName} - {maxScore} points");
        }
    }
}
