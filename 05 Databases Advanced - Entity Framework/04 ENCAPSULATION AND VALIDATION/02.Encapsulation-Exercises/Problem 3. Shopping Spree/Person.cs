namespace Problem_3.Shopping_Spree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person()
        {
            this.Products = new List<Product>();
        }

        public Person(string name, decimal money)
            : this()
        {
            this.Name = name;
            this.Money = money;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get
            {
                return money;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }

        public IReadOnlyCollection<Product> Products
        {
            get
            {
                return this.products;
            }
            private set
            {
                this.products = value.ToList();
            }
        }

        public void BuyProduct(Product product)
        {
            if (product.Price <= this.Money)
            {
                this.Money -= product.Price;
                this.products.Add(product);

                Console.WriteLine($"{this.name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{this.name} can't afford {product.Name}");
            }
        }
    }
}
