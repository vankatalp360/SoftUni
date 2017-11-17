namespace P01_BillsPaymentMethodsystem.Data.Models
{
    public class PaymentMethod
    {
        public PaymentMethod()
        { }

        internal PaymentMethod(PaymentMethodType type, int userId)
        {
            this.Type = type;
            this.UserId = userId;
        }

        public PaymentMethod(PaymentMethodType type, int userId, BankAccount bankAccount)
            :this(type,userId)
        {
            this.BankAccount=bankAccount;
        }

        public PaymentMethod(PaymentMethodType type, int userId, CreditCard creditCard)
            : this(type, userId)
        {
            this.CreditCard = creditCard;
        }

        public int Id { get; set; }

        public PaymentMethodType Type { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int? BankAccountId { get; set; }
        public virtual BankAccount BankAccount { get; set; }

        public int? CreditCardId { get; set; }
        public virtual CreditCard CreditCard { get; set; }
    }
}
