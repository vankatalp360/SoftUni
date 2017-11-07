namespace Problem_4.Pizza_Calories
{
    using System;
    using System.Collections.Generic;

    public class Dough
    {
        private string[] flourTypes = new string[2] { "white", "wholegrain" };
        private string[] bakingTechniques = new string[3] { "crispy", "chewy", "homemade" };
        protected const int caloriesPerGram = 2;
       
        private string flourType;
        private string bakingTechnique;
        private int weight;
        private double totalCalories;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
            this.totalCalories = SetTotalCalories(this.flourType, this.bakingTechnique, this.weight);
        }

        public string FlourType
        {
            get
            {
                return flourType;
            }
            set
            {
                if (value.ToLower()!="white"&&value.ToLower()!="wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.flourType = value;
            }
        }

        public string BakingTechnique
        {
            get
            {
                return bakingTechnique;
            }
            set
            {
                if (value.ToLower() != "crispy"&& value.ToLower() != "chewy"&& value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;
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
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
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
        
        private double SetTotalCalories(string flourType, string bakingTechnique, int weight)
        {
            if (flourType == null || bakingTechnique == null)
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            double flourTypeModifier;
            switch (flourType.ToLower())
            {
                case "white":
                    flourTypeModifier = 1.50;
                    break;
                case "wholegrain":
                    flourTypeModifier = 1.00;
                    break;
                default:
                    throw new ArgumentException("Invalid type of dough.");
            }

            double bakingTechniqueModifier;
            switch (bakingTechnique.ToLower())
            {
                case "crispy":
                    bakingTechniqueModifier = 0.9;
                    break;
                case "chewy":
                    bakingTechniqueModifier = 1.10;
                    break;
                case "homemade":
                    bakingTechniqueModifier = 1.00;
                    break;
                default:
                    throw new ArgumentException("Invalid type of dough.");
            }

            if (this.weight < 1 || this.weight > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }

            return this.totalCalories = weight * caloriesPerGram * flourTypeModifier * bakingTechniqueModifier;
        }
    }
}
