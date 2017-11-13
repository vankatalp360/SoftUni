namespace P03_SaleDatabaseInitializer.Generators
{
    using P03_SalesDatabase;
    using P03_SalesDatabase.Data.Models;
    using System;
    using System.Collections.Generic;

    class StoreGenerator
    {
        internal static void InitialStoreSeed(SalesContext context)
        {
            var storeNames = new string[]
            {
                "The Summit",
                "Bridge Street",
                "Anchorage 5th Avenue Mall",
                "Chandler Fashion Center",
                "SanTan Village",
                "Arrowhead",
                "Biltmore",
                "Scottsdale Quarter",
                "La Encantada"
            };
            
            for (int i = 0; i < storeNames.Length; i++)
            {
                context.Stores.Add(new Store() { Name = storeNames[i] });
            }

            context.SaveChanges();
        }
    }
}
