namespace P01_BillsPayment_ManualSeed.Generators
{
    using P01_BillsPaymentMethodsystem.Data;
    using P01_BillsPaymentMethodsystem.Data.Models;
    using System;

    class BankAccountGenerator
    {
        internal static void Create(BillsPaymentSystemContext context)
        {
            Console.Write($"Bank account balance:");
            decimal balance = decimal.Parse(Console.ReadLine());
            Console.Write("Bank account name:");
            string bankName = Console.ReadLine();
            Console.Write("Bank account SWIFT code:");
            string swiftCode = Console.ReadLine();

            BankAccount bankAccount = new BankAccount(balance,bankName,swiftCode);

            context.BankAccounts.Add(bankAccount);

            context.SaveChanges();
        }
    }
}
