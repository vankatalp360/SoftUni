namespace P01_BillsPaymentMethodsystem.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_BillsPaymentMethodsystem.Data.Models;

    class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder
                .HasKey(c => c.CreditCardId);

            builder
                .Property(c => c.Limit)
                .IsRequired();

            builder
                .Property(c => c.MoneyOwed)
                .IsRequired();

            builder
                .Ignore(c => c.LimitLeft);

            builder
                .Property(c => c.ExpirationDate)
                .IsRequired();

            builder.Ignore(b => b.PaymentMethodId);
        }
    }
}
