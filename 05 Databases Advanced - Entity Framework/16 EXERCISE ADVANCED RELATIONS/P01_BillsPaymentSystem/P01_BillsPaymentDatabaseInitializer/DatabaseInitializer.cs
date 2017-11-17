namespace P01_BillsPaymentDatabaseInitializer
{
    using Microsoft.EntityFrameworkCore;
    using P01_BillsPaymentDatabaseInitializer.Generators;
    using P01_BillsPaymentMethodsystem.Data;
    using System;

    public class DatabaseInitializer
    {
        public static void ResetDatabase()
        {
            using (var context = new BillsPaymentSystemContext())
            {
                context.Database.EnsureDeleted();

                context.Database.Migrate();

                InitialSeed(context);
            }
        }

        public static void InitialSeed(BillsPaymentSystemContext context)
        {
            try
            {
                SeedUsers(context);

                SeedBankAccounts(context);

                SeedCreditCards(context);

                SeedPaymentMethods(context);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void SeedUsers(BillsPaymentSystemContext context)
        {
            UsersGenerator.InitialUserSeed(context, 50);
        }

        private static void SeedBankAccounts(BillsPaymentSystemContext context)
        {
            BankAccountsGenerator.InitialBankAccountSeed(context, 50);
        }

        private static void SeedCreditCards(BillsPaymentSystemContext context)
        {
            CreditCardsGenerator.InitialCreditCardSeed(context, 10);
        }

        private static void SeedPaymentMethods(BillsPaymentSystemContext context)
        {
            PaymentMethodsGenerator.InitialPaymentMethodSeed(context, 60);
        }
    }
}
