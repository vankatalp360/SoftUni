namespace Problem_3.Shopping_Spree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                List<Person> people = new List<Person>();

                ReadPeople(people);

                List<Product> products = new List<Product>();

                ReadProducts(products);

                BuyProducts(people, products);

                PrintPeopleAndBoughtProducts(people);

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void BuyProducts(IEnumerable<Person> people, IEnumerable<Product> products)
        {
            string dataInput;
            while ((dataInput = Console.ReadLine()) != "END")
            {
                string[] tokens = dataInput.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (tokens.Length != 2)
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                string personName = tokens[0];
                string productName = tokens[1];

                Person client = people.FirstOrDefault(x => x.Name == personName);

                Product product = products.FirstOrDefault(x => x.Name == productName);

                if (client == null || product == null)
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                client.BuyProduct(product);
            }
        }

        private static void PrintPeopleAndBoughtProducts(IEnumerable<Person> people)
        {
            foreach (var person in people)
            {
                var result = "Nothing bought";

                if (person.Products.Any())
                {
                    var productNames = person.Products.Select(p => p.Name).ToArray();

                    result = string.Join(", ", productNames);
                }

                Console.WriteLine($"{person.Name} - {result}");
            }
        }

        private static void ReadProducts(IList<Product> products)
        {
            string[] inputProducts = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            foreach (var input in inputProducts)
            {
                string[] els = input.Split('=');
                string productName = els[0].Trim();
                decimal productPrice = decimal.Parse(els[1].Trim());
                products.Add(new Product(productName, productPrice));
            }
        }

        private static void ReadPeople(IList<Person> people)
        {
            string[] inputPeople = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            foreach (var input in inputPeople)
            {
                string[] els = input.Split('=');
                string personName = els[0].Trim();
                decimal personMoney = decimal.Parse(els[1].Trim());
                people.Add(new Person(personName, personMoney));
            }
        }
    }
}
