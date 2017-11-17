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

            int toolId;
            int userId;

            if (type == PaymentMethodType.BankAccount)
            {
                toolId = ReadToolId();

                BankAccount bankAccount = FindBankAccountById(context, toolId);

                userId = ReadUserId();

                User user = FindUserById(context,userId);

                PaymentMethod paymentMethod = new PaymentMethod(PaymentMethodType.BankAccount, userId, bankAccount);

                context.PaymentMethods.Add(paymentMethod);

                context.SaveChanges();
            }
            else if (type == PaymentMethodType.CreditCard)
            {
                toolId = ReadToolId();

                CreditCard creditCard = FindCreditCardById(context, toolId);


                userId = ReadUserId();

                User user = FindUserById(context, userId);

                PaymentMethod paymentMethod = new PaymentMethod(PaymentMethodType.CreditCard, userId, creditCard);

                context.PaymentMethods.Add(paymentMethod);

                context.SaveChanges();
            }
        }

        private static User FindUserById(BillsPaymentSystemContext context, int userId)
        {
            var user = context.Users.Find(userId);

            if (user == null)
            {
                throw new ArgumentException($"User with Id={userId} does not exist.");
            }

            return user;
        }

        private static CreditCard FindCreditCardById(BillsPaymentSystemContext context, int toolId)
        {
            var creditCard = context.CreditCards.Find(toolId);

            if (creditCard == null)
            {
                throw new ArgumentException($"Credit card with Id={toolId} does not exist.");
            }

            var pmCreditCard = (from p in context.PaymentMethods
                                where p.CreditCardId == toolId
                                select p.Id).Count();

            if (pmCreditCard != 0)
            {
                throw new ArgumentException($"Payment method with credit card Id={toolId} alredy exists.");
            }

            return creditCard;
        }

        private static BankAccount FindBankAccountById(BillsPaymentSystemContext context, int toolId)
        {
            var bankAccount = context.BankAccounts.Find(toolId);

            if (bankAccount == null)
            {
                throw new ArgumentException($"Bank account with Id={toolId} does not exist.");
            }

            var bankAccCount = (from p in context.PaymentMethods
                                where p.BankAccountId == toolId
                                select p.Id).Count();

            if (bankAccCount != 0)
            {
                throw new ArgumentException($"Payment method with bank account Id={toolId} alredy exists.");
            }

            return bankAccount;
        }

        private static int ReadUserId()
        {
            int userId;
            Console.Write("User Id:");
            bool Id = int.TryParse(Console.ReadLine(), out userId);

            if (!Id)
            {
                throw new ArgumentException("User Id should be digit.");
            }

            return userId;
        }

        private static int ReadToolId()
        {
            int toolId;
            Console.Write("Payment method Id:");
            bool Id = int.TryParse(Console.ReadLine(), out toolId);

            if (!Id)
            {
                throw new ArgumentException("Id should be digit.");
            }

            return toolId;
        }

        private static PaymentMethodType ReadPaymentType()
        {
            Console.WriteLine("Payment method type:");
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
