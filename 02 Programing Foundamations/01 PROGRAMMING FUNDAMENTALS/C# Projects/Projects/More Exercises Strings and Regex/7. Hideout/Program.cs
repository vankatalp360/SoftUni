using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _7.Hideout
{
    class Program
    {
        static void Main(string[] args)
        {
            string map = Console.ReadLine();
            while (true)
            {
                char[] arrays = Console.ReadLine().ToCharArray();
                char theElement = arrays[0];
                int minCount = int.Parse(string.Join("",arrays.Skip(2).Take(arrays.Length-2)));
                int counter = 0;
                for (int i = 0; i < map.Length; i++)
                {
                    if (map[i] == theElement)
                    {
                        counter++;
                    }
                    else
                    {
                        if (counter >= minCount)
                        {
                            Console.WriteLine($"Hideout found at index {i -counter} and it is with size {counter}!");
                            return;
                        }
                        else
                        {
                            counter = 0;
                        }
                    }
                }
                if (counter >= minCount)
                {
                    Console.WriteLine($"Hideout found at index {map.Length - counter} and it is with size {counter}!");
                    return;
                }
            }
        }
    }
}
