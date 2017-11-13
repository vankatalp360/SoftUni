namespace P03_SaleDatabaseInitializer
{
    using System;
    using P03_SalesDatabase;
    using Microsoft.EntityFrameworkCore;
    using P03_SaleDatabaseInitializer.Generators;

    public class DatabaseInitializer
    {
        public static void ResetDatabase()
        {
            using (var context = new SalesContext())
            {
                context.Database.EnsureDeleted();

                context.Database.Migrate();

                InitialSeed(context);
            }
        }

        public static void InitialSeed(SalesContext context)
        {
            SeedCustomers(context);

            SeedStores(context);

            SeedProducts(context);

            SeedSales(context);
        }

        private static void SeedCustomers(SalesContext context)
        {
            CustomerGenerator.InitialCustomerSeed(context,50);
        }

        private static void SeedStores(SalesContext context)
        {
            StoreGenerator.InitialStoreSeed(context);
        }

        private static void SeedProducts(SalesContext context)
        {
            ProductGenerator.InitialProductSeed(context, 20);
        }

        private static void SeedSales(SalesContext context)
        {
            SaleGenerator.InitialSaleSeed(context, 50);
        }
    }
}
