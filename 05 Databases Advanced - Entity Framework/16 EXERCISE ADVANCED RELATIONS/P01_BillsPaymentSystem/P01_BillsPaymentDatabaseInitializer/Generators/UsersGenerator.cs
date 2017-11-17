namespace P01_BillsPaymentDatabaseInitializer.Generators
{
    using P01_BillsPaymentMethodsystem.Data;
    using P01_BillsPaymentMethodsystem.Data.Models;
    using System;
    using System.Collections.Generic;

    class UsersGenerator
    {
        internal static void InitialUserSeed(BillsPaymentSystemContext context, int number)
        {
            var userFirstNames = new string[]
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

            var userLastNames = new string[]
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

            var emailProviders = new string[]
            {
                "abg.bg",
                "mail.bg",
                "yahoo.com",
                "gmail.com"
            };
            Random rnd = new Random();

            List<User> users = new List<User>();

            for (int i = 0; i < number; i++)
            {
                int userFNIndex = rnd.Next(1, userFirstNames.Length);
                int userLNIndex = rnd.Next(1, userLastNames.Length);
                int emailIndex = rnd.Next(1, emailProviders.Length);

                string firstName = userFirstNames[userFNIndex - 1];
                string lastName = userLastNames[userLNIndex - 1];

                string provider = emailProviders[emailIndex - 1];
                string email = lastName + "@" + provider;

                string passWord = firstName + rnd.Next(1, 100);

                User user = new User(firstName, lastName, email, passWord);

                users.Add(user);
            }

            context.Users.AddRange(users);

            context.SaveChanges();
        }
    }
}
