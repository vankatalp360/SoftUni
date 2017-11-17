namespace P01_BillsPayment_PayBills
{
    using P01_BillsPaymentMethodsystem.Data;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using P01_BillsPaymentMethodsystem.Data.Models;
    using System.Collections.Generic;

    class ExecuteTransactions
    {
        internal static void PayBills(int userId, decimal amount, BillsPaymentSystemContext context)
        {
            var user = context.Users.Find(userId);

            if (user == null)
            {
                throw new ArgumentException($"User with id {userId} not found!");
            }

            var paymentMethods = context.PaymentMethods.Where(pm => pm.UserId == userId).ToArray();

            if (paymentMethods == null)
            {
                throw new ArgumentException($"User with id {userId} not found!");
            }

            List<int> bankAccountIds = new List<int>();

            List<int> creditCardIds = new List<int>();

            foreach (var pm in paymentMethods)
            {
                if (pm.Type == PaymentMethodType.BankAccount && pm.BankAccountId != null)
                {
                    bankAccountIds.Add(pm.BankAccountId.Value);
                }
                else if (pm.CreditCardId != null)
                {
                    creditCardIds.Add(pm.CreditCardId.Value);
                }
            }

            foreach(var bankAccountId in bankAccountIds.OrderBy(x=>x))
            {
                if(amount<=0)
                {
                    break;
                }
                var bankAccount = context.BankAccounts.First(ba => ba.BankAccountId == bankAccountId);
                decimal balance = bankAccount.Balance;
                if (amount <= balance)
                {
                    bankAccount.Withdraw(amount);
                    amount -= balance;
                    break;
                }
                else
                {
                    bankAccount.Withdraw(balance);
                    amount -= balance;
                }
            }

            foreach(var creditCardId in creditCardIds)
            {
                if (amount <= 0)
                {
                    break;
                }
                var creditCard = context.CreditCards.First(cc => cc.CreditCardId == creditCardId);
                decimal leftLimit = creditCard.LimitLeft;
                if (amount <= leftLimit)
                {
                    creditCard.Withdraw(amount);
                    amount -= leftLimit;
                    break;
                }
                else
                {
                    creditCard.Withdraw(leftLimit);
                    amount -= leftLimit;
                }
            }
            

            if (amount <= 0)
            {
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Insufficient funds!");
            }
        }
    }
}
