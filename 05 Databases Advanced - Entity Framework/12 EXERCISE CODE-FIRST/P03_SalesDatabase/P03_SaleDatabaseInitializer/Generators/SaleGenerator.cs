namespace P03_SaleDatabaseInitializer.Generators
{
    using P03_SalesDatabase;
    using P03_SalesDatabase.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class SaleGenerator
    {
        internal static void InitialSaleSeed(SalesContext context, int count)
        {
            Random rnd = new Random();

            int[] allProductIds = context.Products.Select(p => p.ProductId).ToArray();

            int[] allCustomerIds = context.Customers.Select(c => c.CustomerId).ToArray();

            int[] allStoreIds = context.Stores.Select(s => s.StoreId).ToArray();

            for (int i = 0; i < count; i++)
            {
                int ProductId = allProductIds[rnd.Next(0, allProductIds.Length - 1)];
                int CustomerId = allCustomerIds[rnd.Next(0, allCustomerIds.Length - 1)];
                int StoreId = allStoreIds[rnd.Next(0, allStoreIds.Length - 1)];

                context.Sales.Add(new Sale() {
                    Product = context.Products.FirstOrDefault(p => p.ProductId == ProductId),
                    Customer = context.Customers.FirstOrDefault(c => c.CustomerId == CustomerId),
                    Store = context.Stores.FirstOrDefault(s => s.StoreId == StoreId),
                });
            }

            context.SaveChanges();
        }
    }
}
