namespace P01_BillsPayment_UserPaymentMethods
{
    using Microsoft.EntityFrameworkCore;
    using P01_BillsPaymentMethodsystem.Data;
    using System;
    using System.Linq;

    public class UserPaymentMethods
    {
        public static void ReadDetails()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("User Details:");

                int userId;

                while (true)
                {
                    Console.WriteLine(new string('-', 15));
                    Console.WriteLine("///Write 'no digit' to exit.///");
                    Console.WriteLine(new string('-', 15));
                    Console.WriteLine("Please write user ID:");
                    Console.WriteLine(new string('-', 15));
                    if(!int.TryParse(Console.ReadLine(), out userId))
                    {
                        break;
                    }

                    Console.Clear();                   

                    using (var context = new BillsPaymentSystemContext())
                    {
                        var user = context.Users.FirstOrDefault(u => u.UserId == userId);
                        
                        if(user==null)
                        {
                            Console.WriteLine($"User with id {userId} not found!");
                            continue;
                        }

                        Console.WriteLine($"User with userID = {userId} detail:");
                        Console.WriteLine(new string('-', 15));

                        var bankAccounts = context.PaymentMethods
                        .Where(pm => pm.UserId == userId && pm.BankAccount!=null)
                        .Include(pm => pm.BankAccount)                        
                        .Select(pm => new
                        {
                            ID = pm.BankAccountId,
                            Balance = pm.BankAccount.Balance,
                            Bank = pm.BankAccount.BankName,
                            SWIFT = pm.BankAccount.SwiftCode
                        })
                        .ToList();

                        Console.WriteLine($"User: {user.FirstName + " " + user.LastName}");

                        Console.WriteLine("Bank Accounts:");

                        foreach (var acc in bankAccounts)
                        {
                            Console.WriteLine($"-- ID: {acc.ID}");
                            Console.WriteLine($"--- Balance: {acc.Balance:F2}");
                            Console.WriteLine($"--- Bank: {acc.Bank}");
                            Console.WriteLine($"--- SWIFT: {acc.SWIFT}");
                        }

                        string format = "yyyy/MM";

                        var creditCards = context.PaymentMethods
                            .Where(pm => pm.UserId == userId && pm.CreditCard != null)
                            .Include(pm => pm.CreditCard)
                            .Select(pm => new
                            {
                                ID = pm.CreditCardId,
                                Limit = pm.CreditCard.Limit,
                                MoneyOwed = pm.CreditCard.MoneyOwed,
                                LimitLeft = pm.CreditCard.LimitLeft,
                                ExpirationDate = pm.CreditCard.ExpirationDate.ToString(format)
                            })
                            .ToList();

                        Console.WriteLine("Credit Cards:");


                        foreach (var cc in creditCards)
                        {
                            Console.WriteLine($"-- ID: {cc.ID}");
                            Console.WriteLine($"--- Limit: {cc.Limit:F2}");
                            Console.WriteLine($"--- Money Owed: {cc.MoneyOwed}");
                            Console.WriteLine($"--- Limit Left: {cc.LimitLeft}");
                            Console.WriteLine($"--- Expiration Date: {cc.ExpirationDate}");
                        }
                    }
                }                
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
