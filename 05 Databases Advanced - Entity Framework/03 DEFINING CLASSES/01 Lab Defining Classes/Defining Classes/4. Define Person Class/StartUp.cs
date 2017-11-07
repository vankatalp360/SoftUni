using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.Define_Bank_Account_Class;

namespace _4.Define_Person_Class
{
    class StartUp
    {
        static void Main(string[] args)
        {
            BankAccount acc1 = new BankAccount() { ID = 1, Balance = 100 };
            BankAccount acc2 = new BankAccount() { ID = 2, Balance = 200 };
            BankAccount acc3 = new BankAccount() { ID = 3, Balance = 300 };
            List<BankAccount> listacc = new List<BankAccount>() { acc1, acc2, acc3 };
            string name = "Pesho";
            int age = 23;
            Person person = new Person(name, age, listacc);
            Console.WriteLine(person.GetBalance());
        }
    }
}
