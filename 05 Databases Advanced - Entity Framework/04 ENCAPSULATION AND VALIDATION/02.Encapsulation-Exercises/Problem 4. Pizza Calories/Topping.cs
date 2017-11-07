namespace Problem_4.Pizza_Calories
{
    using System;

    public class Topping
    {
        private string[] toppingTypes = new string[4] { "meat", "veggies", "cheese", "sauce" };
        protected const int caloriesPerGram = 2;

        private string toppingType;
        private int weight;
        private double totalCalories;

        public Topping(string toppingType, int weight)
        {
            this.ToppingType = toppingType;
            this.Weight = weight;
            this.totalCalories = SetTotalCalories(toppingType.ToLower(), weight);
        }

        public string ToppingType
        {
            get
            {
                return toppingType;
            }
            set
            {
                if (Array.IndexOf(toppingTypes, value.ToLower()) == -1)
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this.toppingType = value;
            }
        }

        public int Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.ToppingType} weight should be in the range [1..50].");
                }

                this.weight = value;
            }
        }

        public double TotalCalories
        {
            get
            {
                return totalCalories;
            }
        }

        private double SetTotalCalories(string toppingType, int weight)
        {
            if (toppingType == null)
            {
                throw new ArgumentException($"Cannot place {toppingType} on top of your pizza.");
            }

            double toppingTypeModifier;
            switch (toppingType.ToLower())
            {
                case "meat":
                    toppingTypeModifier = 1.20;
                    break;
                case "veggies":
                    toppingTypeModifier = 0.80;
                    break;
                case "cheese":
                    toppingTypeModifier = 1.10;
                    break;
                case "sauce":
                    toppingTypeModifier = 0.90;
                    break;
                default:
                    throw new ArgumentException($"Cannot place {toppingType} on top of your pizza.");
            }

            if (this.weight < 1 || this.weight > 50)
            {
                throw new ArgumentException($"{toppingType} weight should be in the range[1..50].");
            }

            return this.totalCalories = this.weight * caloriesPerGram * toppingTypeModifier;
        }

    }
}
