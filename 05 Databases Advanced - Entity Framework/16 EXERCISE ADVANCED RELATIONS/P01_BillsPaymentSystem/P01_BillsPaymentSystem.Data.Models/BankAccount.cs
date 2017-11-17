namespace P01_BillsPaymentMethodsystem.Data.Models
{
    using System;

    public class BankAccount
    {
        private decimal balance;
        private string bankName;
        private string swiftCode;

        public BankAccount()
        {
        }

        public BankAccount(decimal balance, string bankName, string swiftCode)
        {
            this.Balance = balance;
            this.BankName = bankName;
            this.SwiftCode = swiftCode;
        }

        public BankAccount(decimal balance, string bankName, string swiftCode, int paymentMethodId)
            : this(balance, bankName, swiftCode)
        {
            this.PaymentMethodId = paymentMethodId;
        }

        public BankAccount(decimal balance, string bankName, string swiftCode, PaymentMethod paymentMethod)
            : this(balance, bankName, swiftCode)
        {
            this.PaymentMethod = paymentMethod;
        }

        public int BankAccountId { get; set; }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Balance should be not negative.");
                }
                this.balance = value;
            }
        }

        public string BankName
        {
            get
            {
                return this.bankName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Bank name should be not emplty or whitespace.");
                }
                this.bankName = value;
            }
        }

        public string SwiftCode
        {
            get
            {
                return this.swiftCode;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("SWIFT Code should be not emplty or whitespace.");
                }
                this.swiftCode = value;
            }
        }

        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public void Withdraw(decimal amount)
        {
            if(amount<0)
            {
                throw new ArgumentException("Amount should not be negative.");
            }
            if (amount>this.Balance)
            {
                throw new ArgumentException("Insufficient funds!");
            }
            this.Balance -= amount;
        }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount should not be negative.");
            }
            this.Balance += amount;
        }
    }
}
