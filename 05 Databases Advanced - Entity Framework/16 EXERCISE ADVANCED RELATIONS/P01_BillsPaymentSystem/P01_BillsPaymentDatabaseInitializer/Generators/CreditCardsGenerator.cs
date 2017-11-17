namespace P01_BillsPaymentDatabaseInitializer.Generators
{
    using P01_BillsPaymentMethodsystem.Data;
    using P01_BillsPaymentMethodsystem.Data.Models;
    using System;
    using System.Collections.Generic;

    class CreditCardsGenerator
    {
        internal static void InitialCreditCardSeed(BillsPaymentSystemContext context, int number)
        {
            Random rnd = new Random();

            List<CreditCard> creditCards = new List<CreditCard>();

            for (int i = 0; i < number; i++)
            {
                DateTime expirationDate = DateTime.Now;
                int days = rnd.Next(1, 1000);
                expirationDate=expirationDate.AddDays(days);

                decimal limit = 5000m + rnd.Next(1, 5000) + rnd.Next(1, 100) / 100m;

                decimal moneyOwed = rnd.Next(1, 4900)+rnd.Next(1,100)/100m;

                CreditCard bankAccount = new CreditCard(limit,moneyOwed,expirationDate);

                creditCards.Add(bankAccount);
            }

            context.CreditCards.AddRange(creditCards);

            context.SaveChanges();
        }
    }
}
