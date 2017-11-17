namespace P01_BillsPaymentMethodsystem.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_BillsPaymentMethodsystem.Data.Models;

    class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder
                .HasKey(b => b.BankAccountId);

            builder
                .Property(b => b.Balance)
                .IsRequired();

            builder
                .Property(b => b.BankName)
                .IsRequired()
                .IsUnicode(true)
                .HasMaxLength(50);

            builder
                .Property(b => b.SwiftCode)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(20);

            builder.Ignore(b => b.PaymentMethodId);
        }
    }
}
