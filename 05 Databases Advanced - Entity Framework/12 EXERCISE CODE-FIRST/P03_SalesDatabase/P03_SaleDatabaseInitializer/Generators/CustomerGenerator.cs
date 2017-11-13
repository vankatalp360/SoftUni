namespace P03_SaleDatabaseInitializer.Generators
{
    using P03_SalesDatabase;
    using P03_SalesDatabase.Data.Models;
    using System;
    using System.Collections.Generic;

    class CustomerGenerator
    {
        internal static void InitialCustomerSeed(SalesContext context, int number)
        {
            var customerFirstNames = new string[]
            {
                "Ivan",
                "Petko",
                "Hristo",
                "Stanislav",
                "Ivaylo",
                "Kosta",
                "Efrem",
                "Todor",
                "Ico",
                "Stefan",
                "Vlado",
                "Viktor",
                "Mihayl",
            };

            var customerLastNames = new string[]
            {
                "Ivanov",
                "Petkov",
                "Hristov",
                "Petrov",
                "Ivaylov",
                "Kostadinov",
                "Draganov",
                "Todorov",
                "Borisov",
                "Stefanov",
                "Vladimirov",
                "Viktorov",
                "Mihaylov",
            };

            Random rnd = new Random();

            List<string> customerNames = new List<string>();

            for (int i = 0; i<number;i++)
            {
                int customerFNIndex = rnd.Next(1, customerFirstNames.Length);
                int customerLNIndex = rnd.Next(1, customerLastNames.Length);
                string customerName = customerFirstNames[customerFNIndex - 1] + " "+ customerLastNames[customerLNIndex - 1];
                customerNames.Add(customerName);
            }

            for (int i = 0; i < customerNames.Count; i++)
            {
                context.Customers.Add(new Customer() { Name = customerNames[i] });
            }

            context.SaveChanges();
        }
    }
}
