namespace P01_BillsPaymentMethodsystem.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_BillsPaymentMethodsystem.Data.Models;

    class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Type)
                .IsRequired();

            builder
                .Property(p => p.UserId)
                .IsRequired();

            builder
                .HasOne(p => p.User)
                .WithMany(u => u.PaymentMethods)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
               .Property(p => p.BankAccountId)
               .IsRequired(false);

            builder
               .HasOne(p => p.BankAccount)
               .WithOne(b => b.PaymentMethod)
               .HasForeignKey<PaymentMethod>(p => p.BankAccountId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
               .Property(p => p.CreditCardId)
               .IsRequired(false);

            builder
                .HasOne(p => p.CreditCard)
                .WithOne(c => c.PaymentMethod)
                .HasForeignKey<PaymentMethod>(p => p.CreditCardId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasIndex(p => new { p.UserId, p.BankAccountId, p.CreditCardId }).IsUnique();
        }
    }
}
