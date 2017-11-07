namespace Problem_4.Pizza_Calories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Pizza
    {
        protected const int caloriesPerGram = 2;

        private string name;
        private List<Topping> toppings;
        private Dough dough;

        public Pizza()
        {
            this.Toppings = new List<Topping>();
        }

        public Pizza(string name) : this()
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }

        public Dough Dough
        {
            get
            {
                return this.dough;
            }
            set
            {
                this.dough = value;
            }
        }

        public IReadOnlyCollection<Topping> Toppings
        {
            get
            {
                return this.toppings;
            }
            private set
            {
                this.toppings = value.ToList();
            }
        }

        public int NumberOfToppings()
        {
            return this.toppings.Count;
        }

        public void AddTopping(Topping topping)
        {
            if (NumberOfToppings() == 10)
            {
                throw new ArgumentException($"Number of toppings should be in range [0..10].");
            }
            this.toppings.Add(topping);
        }

        public double CalculateTotalCalories()
        {
            double doughTotalCalories = 0;
            if (dough != null)
            {
                doughTotalCalories = dough.TotalCalories;
            }
            double toppingTotalCalories = 0;

            if (NumberOfToppings() != 0)
            {
                foreach (var topping in toppings)
                {
                    toppingTotalCalories += topping.TotalCalories;
                }
            }
            return doughTotalCalories + toppingTotalCalories;
        }
    }
}
