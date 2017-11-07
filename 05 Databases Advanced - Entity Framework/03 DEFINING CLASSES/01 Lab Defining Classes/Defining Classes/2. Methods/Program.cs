using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.Define_Bank_Account_Class;

namespace _2.Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            _1.Define_Bank_Account_Class.BankAccount acc = new _1.Define_Bank_Account_Class.BankAccount();

            acc.ID = 1;
            acc.Deposit(15);
            acc.Withdraw(5);

            Console.WriteLine($"Account {acc.ID}, balance {acc.Balance}");
        }
    }
}
