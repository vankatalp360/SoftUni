using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Define_Bank_Account_Class
{
    public class BankAccount
    {
        public int ID { get; set; }
        public decimal Balance { get; set; }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("Unacceptable negative amount!");
            }
            else
            {
                this.Balance += amount;
            }
        }

        public void Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("Unacceptable negative amount!");
            }
            else
            {
                if (this.Balance >= amount)
                {
                    this.Balance -= amount;
                }
                else
                {
                    Console.WriteLine("Insufficient balance");
                }
            }            
        }
    }
}
