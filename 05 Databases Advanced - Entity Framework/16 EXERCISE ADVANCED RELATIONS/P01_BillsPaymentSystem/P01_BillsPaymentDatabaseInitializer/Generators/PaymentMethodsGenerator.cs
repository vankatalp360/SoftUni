namespace P01_BillsPaymentDatabaseInitializer.Generators
{
    using P01_BillsPaymentMethodsystem.Data;
    using P01_BillsPaymentMethodsystem.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class PaymentMethodsGenerator
    {
        internal static void InitialPaymentMethodSeed(BillsPaymentSystemContext context, int number)
        {
            Random rnd = new Random();
            
            var creditCardIds = (from p in context.PaymentMethods
                                where p.CreditCardId != null
                                 select p.CreditCardId).ToHashSet();

            var bankAccountIds = (from p in context.PaymentMethods
                                 where p.BankAccountId != null
                                 select p.BankAccountId).ToHashSet();

            List<PaymentMethod> paymentMethods = new List<PaymentMethod>();

            for (int i = 0; i < number; i++)
            {
                int usersCount = context.Users.Count();

                int userId = rnd.Next(1, usersCount);

                var user = context.Users.FirstOrDefault(u => u.UserId == userId);
                
                if (i % 3 == 0)
                {
                    int creditCardsCount = context.CreditCards.Count();

                    int creditCardId = rnd.Next(1, creditCardsCount);

                    if(creditCardIds.Contains(creditCardId))
                    {
                        continue;
                    }

                    creditCardIds.Add(creditCardId);

                    var creditCard = context.CreditCards.FirstOrDefault(c => c.CreditCardId == creditCardId);

                    var paymentMethod = new PaymentMethod
                    {
                        CreditCard = creditCard,
                        Type = PaymentMethodType.CreditCard,
                        User = user
                    };

                    paymentMethods.Add(paymentMethod);
                }
                else
                {
                    int bankAccountCount = context.BankAccounts.Count();

                    int bankAccounrId = rnd.Next(1, bankAccountCount);

                    if (bankAccountIds.Contains(bankAccounrId))
                    {
                        continue;
                    }

                    bankAccountIds.Add(bankAccounrId);

                    var bankAccount = context.BankAccounts.FirstOrDefault(b => b.BankAccountId == bankAccounrId);
                    
                    var paymentMethod = new PaymentMethod
                    {
                        BankAccount = bankAccount,
                        Type = PaymentMethodType.BankAccount,
                        User = user
                    };

                    paymentMethods.Add(paymentMethod);
                }
            }

            context.PaymentMethods.AddRange(paymentMethods);

            context.SaveChanges();
        }
    }
}
