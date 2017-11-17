namespace P01_BillsPayment_ManualSeed.Generators
{
    using P01_BillsPaymentMethodsystem.Data;
    using P01_BillsPaymentMethodsystem.Data.Models;
    using System;
    using System.Linq;

    class PaymentMethodGenerator
    {
        internal static void Create(BillsPaymentSystemContext context)
        {

            PaymentMethodType type = ReadPaymentType();

            int Id;

            if (type == PaymentMethodType.BankAccount)
            {
                Console.Write("Payment method bank accound Id:");
                bool bankAccountId = int.TryParse(Console.ReadLine(), out Id);

                if(!bankAccountId)
                {
                    throw new ArgumentException("Bank account Id should be digit.");
                }

                var bankAccount = context.CreditCards.Find(Id);

                if (bankAccount == null)
                {
                    throw new ArgumentException($"Credit card with Id={Id} does not exist.");
                }

                var bankAcc = (from p in context.PaymentMethods
                               where p.BankAccountId == Id
                               select p.Id).Count();

                if(bankAcc!=0)
                {
                    throw new ArgumentException($"Payment method with bank account Id={Id} alredy exists.");
                }

                PaymentMethod paymentMethod = new PaymentMethod(type,Id, bankAccount);

                context.PaymentMethods.Add(paymentMethod);

                context.SaveChanges();
            }
            else if (type == PaymentMethodType.CreditCard)
            {
                Console.Write("Payment method credit card Id:");
                bool creditCardId = int.TryParse(Console.ReadLine(), out Id);

                if (!creditCardId)
                {
                    throw new ArgumentException("Credit card Id should be digit.");
                }

                var creditCard = context.CreditCards.Find(Id);

                if (creditCard == null)
                {
                    throw new ArgumentException($"Credit card with Id={Id} does not exist.");
                }

                var pmCreditCard = (from p in context.PaymentMethods
                               where p.CreditCardId == Id
                               select p.Id).Count();

                if (pmCreditCard != 0)
                {
                    throw new ArgumentException($"Payment method with credit card Id={Id} alredy exists.");
                }

                PaymentMethod paymentMethod = new PaymentMethod(type, Id, creditCard);

                context.PaymentMethods.Add(paymentMethod);

                context.SaveChanges();
            }
        }

        private static PaymentMethodType ReadPaymentType()
        {
            Console.Write("Payment method type:");
            Console.WriteLine("1. BankAccount - use '1';");
            Console.WriteLine("2. Credit Card - use '2';");
            int typeId = int.Parse(Console.ReadLine());

            PaymentMethodType type = new PaymentMethodType();

            switch (typeId)
            {
                case 1:
                    type = PaymentMethodType.BankAccount;
                    break;
                case 2:
                    type = PaymentMethodType.CreditCard;
                    break;
                default:
                    throw new ArgumentException("There is no such type.");
            }

            return type;
        }
    }
}
