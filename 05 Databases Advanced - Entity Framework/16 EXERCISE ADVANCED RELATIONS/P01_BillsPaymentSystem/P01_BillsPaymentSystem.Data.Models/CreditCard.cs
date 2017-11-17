namespace P01_BillsPaymentMethodsystem.Data.Models
{
    using System;

    public class CreditCard
    {
        private decimal limit;
        private decimal moneyOwed;
        private DateTime expirationDate;

        public CreditCard()
        { }

        public CreditCard(decimal limit, decimal moneyOwed, DateTime expirationDate)
        {
            this.Limit = limit;
            this.MoneyOwed = moneyOwed;
            this.ExpirationDate = expirationDate;
        }

        public int CreditCardId { get; set; }

        public decimal Limit
        {
            get
            {
                return this.limit;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Limit should be not negative.");
                }
                this.limit = value;
            }
        }

        public decimal MoneyOwed
        {
            get
            {
                return this.moneyOwed;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money owed by you should be not negative.");
                }
                if (value > this.Limit)
                {
                    throw new ArgumentException("Money owed by you should be less than our Limit.");
                }
                this.moneyOwed = value;
            }
        }

        public decimal LimitLeft
        {
            get
            { 
                return CalculateLimitLeft();
            }
        }       

        public DateTime ExpirationDate {
            get
            {
                return this.expirationDate;
            }
            set
            {
                DateTime dateNow = DateTime.Now;

                if(dateNow>value)
                {
                    throw new ArgumentException("Credit card expiration date should be latter date than today.");
                }
                this.expirationDate = value;
            }
        }

        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        private decimal CalculateLimitLeft()
        {
            return this.Limit - this.MoneyOwed;
        }

        public void Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount should not be negative.");
            }
            if (amount > this.LimitLeft)
            {
                throw new ArgumentException("Insufficient funds!");
            }
            this.MoneyOwed += amount;
        }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount should not be negative.");
            }

            if (amount <= this.MoneyOwed)
            {
                this.MoneyOwed += amount;
            }
            else
            {
                this.Limit += amount - this.MoneyOwed;
                this.MoneyOwed = 0;
            }
        }
    }
}
