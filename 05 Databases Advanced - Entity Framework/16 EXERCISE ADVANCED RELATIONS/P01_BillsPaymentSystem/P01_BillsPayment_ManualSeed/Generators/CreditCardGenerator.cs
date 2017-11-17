namespace P01_BillsPayment_ManualSeed.Generators
{
    using P01_BillsPaymentMethodsystem.Data;
    using P01_BillsPaymentMethodsystem.Data.Models;
    using System;
    using System.Globalization;

    class CreditCardGenerator
    {
        internal static void Create(BillsPaymentSystemContext context)
        {
            string format = "yyyy/MM";
            Console.Write($"Credit card expiration date ({format}):");
            DateTime expirationDate = DateTime.ParseExact(Console.ReadLine(),format , CultureInfo.InvariantCulture);
            Console.Write("Credit card limit:");
            decimal limit = decimal.Parse(Console.ReadLine());
            Console.Write("Credit card money owed:");
            decimal moneyOwed = decimal.Parse(Console.ReadLine());

            CreditCard creditCard = new CreditCard(limit,moneyOwed,expirationDate);

            context.CreditCards.Add(creditCard);

            context.SaveChanges();
        }
    }
}
