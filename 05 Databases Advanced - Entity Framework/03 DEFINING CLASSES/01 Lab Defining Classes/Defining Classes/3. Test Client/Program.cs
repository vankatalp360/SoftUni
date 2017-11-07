using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1.Define_Bank_Account_Class;


namespace _3.Test_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, BankAccount> clientsAccounts = new Dictionary<int, BankAccount>();
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] commands = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                ManipulateAccounts(clientsAccounts, commands);
                input = Console.ReadLine();
            }
        }

        private static void ManipulateAccounts(Dictionary<int, BankAccount> clientsAccounts, string[] commands)
        {
            switch (commands[0])
            {
                case "Create":
                    CreateNewAccount(clientsAccounts, commands);
                    break;
                case "Deposit":                    
                    DepositInCurrentAccount(clientsAccounts, commands);
                    break;
                case "Withdraw":                    
                    WithdrawFromCurrentAccount(clientsAccounts, commands);
                    break;
                case "Print":
                    PrintAccount(clientsAccounts, commands);
                    break;
            }
        }

        private static void PrintAccount(Dictionary<int, BankAccount> clientsAccounts, string[] commands)
        {
            int clientID = int.Parse(commands[1]);
            if (clientsAccounts.ContainsKey(clientID))
            {
                BankAccount currentClientAccount = clientsAccounts[clientID];
                Console.WriteLine($"Account {currentClientAccount.ID}, balance {currentClientAccount.Balance}");
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        private static void WithdrawFromCurrentAccount(Dictionary<int, BankAccount> clientsAccounts, string[] commands)
        {
            int clientID = int.Parse(commands[1]);
            decimal amount = decimal.Parse(commands[2]);
            if (clientsAccounts.ContainsKey(clientID))
            {
                BankAccount currentClientAccount = clientsAccounts[clientID];

                currentClientAccount.Withdraw(amount);
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        private static void DepositInCurrentAccount(Dictionary<int, BankAccount> clientsAccounts, string[] commands)
        {
            int clientID = int.Parse(commands[1]);
            decimal amount = decimal.Parse(commands[2]);
            if (clientsAccounts.ContainsKey(clientID))
            {
                BankAccount currentClientAccount = clientsAccounts[clientID];

                currentClientAccount.Deposit(amount);
            }
            else
            {
                Console.WriteLine("Account does not exist");
            }
        }

        private static void CreateNewAccount(Dictionary<int, BankAccount> clientsAccounts, string[] commands)
        {
            int clientID = int.Parse(commands[1]);
            if (clientsAccounts.ContainsKey(clientID))
            {
                Console.WriteLine("Account already exists");
            }
            else
            {
                BankAccount acc = new BankAccount();
                acc.ID = clientID;
                clientsAccounts.Add(clientID, acc);
            }
        }
    }
}
