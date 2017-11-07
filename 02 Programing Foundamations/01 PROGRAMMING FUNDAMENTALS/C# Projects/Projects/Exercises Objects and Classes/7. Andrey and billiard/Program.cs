using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Andrey_and_billiard
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InstalledUICulture;
            Dictionary<string, double> entitiesPrices = DefineTheEntitiesAndPrices();
            List<Customer> customers = new List<Customer>();
            while (true)
            {
                string[] currentOrder = Console.ReadLine().Split(new char[] { ',', '-'}).Select(x=>x.Trim()).ToArray();
                if (currentOrder[0] == "end of clients") break;
                string name = currentOrder[0];
                string entity = currentOrder[1];
                if (!entitiesPrices.ContainsKey(entity)) continue;
                int quantity = int.Parse(currentOrder[2]);                
                AddNewCustomer(customers, entity, name);
                int index = EstablishCustommerPossition(customers, name);
                AddTheNewCustomerOrder(entitiesPrices, customers, entity, quantity, index);
            }
            PrintTheResult(customers);
        }

        private static void PrintTheResult(List<Customer> customers)
        {
            foreach (var client in customers.OrderBy(x => x.Name))
            {
                Console.WriteLine(client.Name);
                foreach (var item in client.Order)
                {
                    Console.WriteLine($"-- {item.Key} - {item.Value}");
                }
                Console.WriteLine($"Bill: {client.Bill:F2}");
            }
            Console.WriteLine($"Total bill: {customers.Sum(x => x.Bill):f2}");
        }

        private static void AddTheNewCustomerOrder(Dictionary<string, double> entitiesPrices, List<Customer> customers, string entity, int quantity, int index)
        {
            Customer currentCustomer = customers[index];
            Dictionary<string, int> currentCustomerOrder = currentCustomer.Order;
            if (!currentCustomerOrder.ContainsKey(entity))
            {
                currentCustomerOrder[entity] = 0;
            }
            currentCustomerOrder[entity] += quantity;
            currentCustomer.Bill = CalculateBill(currentCustomer.Order, entitiesPrices);
            customers[index] = currentCustomer;
        }

        private static int EstablishCustommerPossition(List<Customer> customers, string name)
        {
            int index = 0;
            foreach (var customer in customers)
            {
                if (customer.Name != name) index++;
                else break;
            }

            return index;
        }

        private static void AddNewCustomer(List<Customer> customers, string entity, string name)
        {
            if (!customers.Select(x => x.Name).Contains(name))
            {
                Customer newCustomer = new Customer();
                newCustomer.Name = name;
                newCustomer.Order = new Dictionary<string, int>();
                newCustomer.Order[entity] = 0;
                newCustomer.Bill = 0;
                customers.Add(newCustomer);
            }
        }

        private static double CalculateBill(Dictionary<string, int> order, Dictionary<string, double> entitiesPrices)
        {
            double totalBill = 0;
            foreach (var product in order)
            {
                totalBill += entitiesPrices[product.Key] * product.Value;
            }
            return totalBill;
        }

        public static Dictionary<string, double> DefineTheEntitiesAndPrices()
        {
            Dictionary<string, double> entitiesPrices = new Dictionary<string, double>();
            int number = int.Parse(Console.ReadLine());
            for (int i = 1; i <= number; i++)
            {
                string[] input = Console.ReadLine().Split('-').ToArray();
                string entity = input[0];
                double price = double.Parse(input[1]);
                entitiesPrices[entity] = price;
            }
            return entitiesPrices;
        }
    }
    class Customer
    {
        public string Name { get; set; }
        public Dictionary<string, int> Order { get; set; }
        public double Bill { get; set; }
    }
}
