namespace P01_BillsPaymentDatabaseInitializer.Generators
{
    using P01_BillsPaymentMethodsystem.Data;
    using P01_BillsPaymentMethodsystem.Data.Models;
    using System;
    using System.Collections.Generic;

    class BankAccountsGenerator
    {
        internal static void InitialBankAccountSeed(BillsPaymentSystemContext context, int number)
        {
            var bankNames = new string[]
            {
                "Eagle Savings Association",
                "Intermountain Savings Bank",
                "Advest Trust Company",
                "CFBank",
                "The Lytle State Bank",
                "Quincy-Peoples Savings and Loan Association",
                "United Building Association",
                "EastBank",
                "CommerceFirst Bank",
                "California Oaks State Bank",
                "First Network Federal Savings Bank",
                "KS Bank",
                "United Jersey Bank/Lenape State",
                "Laurel Savings Bank",
                "Patriot Federal Savings and Loan Association",
                "The Trust Bank",
                "Connecticut Valley Bank",
                "Peoples Trust Company",
                "Sun Bank/Hillsborough",
                "Schaumburg Bank & Trust Company",
                "West Houston National Bank",
                "Ozark Bank",
                "New Republic Savings Bank",
                "First RepublicBank Stephenville",
                "MBank Denton County"
            };

            Random rnd = new Random();

            List<BankAccount> bankAccounts = new List<BankAccount>();

            for (int i = 0; i < number; i++)
            {
                int bankIndex = rnd.Next(1, bankNames.Length);
               
                string bankName = bankNames[bankIndex - 1];

                decimal balance =rnd.Next(1000, 10000) + rnd.Next(1, 100) / 100m;

                string swiftCode = bankName.Substring(0, 4)+" ab cd eee";

                BankAccount bankAccount = new BankAccount(balance,bankName, swiftCode);

                bankAccounts.Add(bankAccount);
            }

            context.BankAccounts.AddRange(bankAccounts);

            context.SaveChanges();
        }
    }
}
