using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> disPokemons = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            long result = 0;
            int value;
            while (disPokemons.Count != 0)
            {
                int index = int.Parse(Console.ReadLine());
                if (index < 0)
                {
                    value = disPokemons[0];
                    disPokemons[0] = disPokemons[disPokemons.Count - 1];
                }
                else if (index >= disPokemons.Count)
                {
                    value = disPokemons[disPokemons.Count - 1];
                    disPokemons[disPokemons.Count - 1] = disPokemons[0];
                }
                else
                {
                    value = disPokemons[index];
                    disPokemons.RemoveAt(index);
                }
                result += value;
                for (int i = 0; i < disPokemons.Count; i++)
                {
                    if (disPokemons[i] <= value)
                    {
                        disPokemons[i] += value;
                    }
                    else
                    {
                        disPokemons[i] -= value;
                    }
                }
            }
            Console.WriteLine(result);
        }
    }
}

