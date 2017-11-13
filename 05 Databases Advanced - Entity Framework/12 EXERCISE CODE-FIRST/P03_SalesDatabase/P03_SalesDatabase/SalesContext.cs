namespace P03_SalesDatabase
{
    using Microsoft.EntityFrameworkCore;
    using P03_SalesDatabase.Data;
    using P03_SalesDatabase.Data.Models;

    public class SalesContext : DbContext
    {
        public SalesContext()
           : base()
        { }

        public SalesContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Customer> Customers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.Property(e => e.Name)
                      .IsUnicode(true)
                      .HasMaxLength(100);

                entity.Property(e => e.Email)
                      .IsUnicode(false)
                      .HasMaxLength(80);
            });

            builder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.Property(e => e.Name)
                      .IsUnicode(true)
                      .HasMaxLength(50);

                entity.Property(e => e.Description)
                      .HasMaxLength(250)
                      .HasDefaultValue("No description");
            });

            builder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.StoreId);

                entity.Property(e => e.Name)
                      .IsUnicode(true)
                      .HasMaxLength(80);
            });

            builder.Entity<Sale>(entity =>
            {
                entity.HasKey(e => e.SaleId);

                entity.Property(e => e.Date)
                      .HasDefaultValueSql("GETDATE()");

                entity.HasOne(e => e.Product)
                       .WithMany(p => p.Sales)
                       .HasForeignKey(e => e.ProductId)
                       .HasConstraintName("FK_Sales_Products");

                entity.HasOne(e => e.Customer)
                       .WithMany(c => c.Sales)
                       .HasForeignKey(e => e.CustomerId)
                       .HasConstraintName("FK_Sales_Custmers");

                entity.HasOne(e => e.Store)
                       .WithMany(s => s.Sales)
                       .HasForeignKey(e => e.StoreId)
                       .HasConstraintName("FK_Sales_Stores");
            });
        }
    }
}
