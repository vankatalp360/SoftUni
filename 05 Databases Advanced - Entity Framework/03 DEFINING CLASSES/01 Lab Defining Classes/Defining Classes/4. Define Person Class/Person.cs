using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.Define_Bank_Account_Class;


namespace _4.Define_Person_Class
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<BankAccount> Accounts { get; set; }

        public Person()
        {
            this.Accounts = new List<BankAccount>();
        }

        public Person(string Name, int Age):this()
        {
            this.Name = Name;
            this.Age = Age;
        }

        public Person(string Name, int Age, List<BankAccount>accounts):this(Name, Age)
        {
            this.Accounts = accounts;
        }

        public decimal GetBalance()
        {
            return this.Accounts.Select(x=>x.Balance).Sum();
        }
    }
}
