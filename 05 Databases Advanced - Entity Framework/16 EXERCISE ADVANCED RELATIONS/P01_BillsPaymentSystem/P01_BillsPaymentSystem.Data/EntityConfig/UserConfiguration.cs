namespace P01_BillsPaymentMethodsystem.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_BillsPaymentMethodsystem.Data.Models;

    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(u => u.UserId);

            builder
                .Property(u => u.FirstName)
                .IsRequired()
                .IsUnicode(true)
                .HasMaxLength(50);

            builder
                .Property(u => u.LastName)
                .IsRequired()
                .IsUnicode(true)
                .HasMaxLength(50);

            builder
                .Property(u => u.Email)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(80);

            builder
                .Property(u => u.Password)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(25);
        }
    }
}
