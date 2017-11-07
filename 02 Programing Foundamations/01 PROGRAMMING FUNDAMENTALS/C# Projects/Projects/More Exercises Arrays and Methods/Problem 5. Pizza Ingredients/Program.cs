using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_5.Pizza_Ingredients
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] ingredients = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            long length = long.Parse(Console.ReadLine());
            string[] recipe = new string[10];
            int countIngredients = 0;
            foreach (string ingredient in ingredients)
            {
                if (countIngredients == 10) break;
                if (ingredient.Length == length)
                {
                    recipe[countIngredients] = ingredient;
                    Console.WriteLine($"Adding {ingredient}.");
                    countIngredients++;
                }
            }
            Array.Resize(ref recipe, countIngredients);
            Console.WriteLine($"Made pizza with total of {countIngredients} ingredients.");
            Console.WriteLine($"The ingredients are: {string.Join(", ", recipe)}.");
        }
    }
}
