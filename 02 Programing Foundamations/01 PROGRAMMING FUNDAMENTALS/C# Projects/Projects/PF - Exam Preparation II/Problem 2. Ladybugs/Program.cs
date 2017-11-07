using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Ladybugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfField = int.Parse(Console.ReadLine());
            string filledFields = Console.ReadLine().Trim();
            List<long> indexOfLadybug = new List<long>();
            if (!String.IsNullOrEmpty(filledFields)) indexOfLadybug = filledFields.Split().Distinct().OrderBy(x => x).Select(long.Parse).Where(x => (x < sizeOfField&&x>=0)).ToList();
            int i = 1;
            int[] massive = DefineTheArray(sizeOfField, indexOfLadybug);
            if (sizeOfField > 0 && sizeOfField <= 1000)
            {
                
                while (true)
                {
                    string command = Console.ReadLine();
                    i++;
                    if (command == "end") break;
                    if (i > 100) continue;
                    if (sizeOfField <= 0) continue;
                    if (String.IsNullOrEmpty(command)) continue;
                    string[] commands = command.Split(' ').ToArray();
                    long currentIndex = long.Parse(commands[0]);
                    if (currentIndex >= sizeOfField || currentIndex < 0) continue;
                    if (massive[currentIndex] == 0) continue;
                    massive[currentIndex] = 0;                                       
                    long flyLength = long.Parse(commands[2]);
                    if (flyLength > 2147483647 && flyLength < -2147483647) continue;
                    string direction = commands[1];
                    if (direction == "right")
                    {
                        if (flyLength >= 0) GoToRight(sizeOfField, massive, (int)currentIndex, flyLength);
                        else GoToLeft(sizeOfField, massive, (int)currentIndex, Math.Abs(flyLength));
                    }
                    else if (direction == "left")
                        if (flyLength >= 0) GoToLeft(sizeOfField, massive, (int)currentIndex, flyLength);
                        else GoToRight(sizeOfField, massive, (int)currentIndex, Math.Abs(flyLength));
                }
                Console.WriteLine(string.Join(" ", massive));
            }
            else
            {
                while (true)
                {
                    string command = Console.ReadLine();
                    i++;
                    if (command == "end") break;
                    if (i > 100) continue;
                }
                Console.WriteLine(string.Join(" ", massive));
            }
        }

        private static void GoToLeft(int sizeOfField, int[] massive, int currentIndex, long flyLength)
        {
            int index = currentIndex - (int)flyLength;
            if (index >= 0 && index < sizeOfField)
            {
                while (massive[index] == 1)
                {
                    index -= (int)flyLength;
                    if (index < 0) break;
                }
                if (index >= 0) massive[index] = 1;
            }
        }

        private static void GoToRight(int sizeOfField, int[] massive, int currentIndex, long flyLength)
        {
            int index = currentIndex + (int)flyLength;
            if (index >= 0 && index < sizeOfField)
            {
                while (massive[index] == 1)
                {
                    index += (int)flyLength;
                    if (index == sizeOfField) break;
                }
                if (index < sizeOfField) massive[index] = 1;
            }
        }

        private static int[] DefineTheArray(int sizeOfField, List<long> indexOfLadybug)
        {
            int[] massive = new int[sizeOfField];
            foreach (long i in indexOfLadybug)
            {
                if (massive[i] != 1) massive[i] = 1;
            }
            return massive;
        }
    }
}

