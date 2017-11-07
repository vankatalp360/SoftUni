namespace Problem_4.Pizza_Calories
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                string[] tokensPizza = Console.ReadLine().Split();
                string pizzaName = tokensPizza[1];
                Pizza pizza = new Pizza(pizzaName);

                string[] tokensDough = Console.ReadLine().Split();
                string flourType = tokensDough[1];
                string bakingTechnique = tokensDough[2];
                int weightD = int.Parse(tokensDough[3]);
                Dough dough = new Dough(flourType, bakingTechnique, weightD);

                pizza.Dough = dough;

                string input;

                while ((input = Console.ReadLine()) != "END")
                {
                    string[] tokensTopping = input.Split();
                    string toppingType = tokensTopping[1];
                    int toppingWeight = int.Parse(tokensTopping[2]);
                    Topping topping = new Topping(toppingType, toppingWeight);
                    pizza.AddTopping(topping);
                }

                Console.WriteLine($"{pizza.Name} - {pizza.CalculateTotalCalories():F2} Calories.");
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
