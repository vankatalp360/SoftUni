namespace P01_BillsPayment_ManualSeed.Generators
{
    using P01_BillsPaymentMethodsystem.Data;
    using P01_BillsPaymentMethodsystem.Data.Models;
    using System;

    class UserGenerator
    {
        internal static void Create(BillsPaymentSystemContext context)
        {
            Console.Write("User email:");
            string email = Console.ReadLine();
            Console.Write("User first name:");
            string firstName = Console.ReadLine();
            Console.Write("User last name:");
            string lastName = Console.ReadLine();
            Console.Write("User password:");
            string password = Console.ReadLine();

            User user = new User(firstName, lastName, email, password);

            context.Users.Add(user);

            context.SaveChanges();
        }
    }
}
