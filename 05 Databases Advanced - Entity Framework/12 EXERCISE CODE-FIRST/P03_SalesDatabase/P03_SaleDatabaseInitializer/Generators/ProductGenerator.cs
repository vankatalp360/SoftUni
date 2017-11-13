namespace P03_SaleDatabaseInitializer.Generators
{
    using P03_SalesDatabase;
    using P03_SalesDatabase.Data.Models;
    using System;
    using System.Collections.Generic;

    class ProductGenerator
    {
        internal static void InitialProductSeed(SalesContext context, int number)
        {
            var productNames = new string[]
            {
                "Accessories",
                "Blouses & Shirts",
                "Coats & Jackets",
                "Dresses",
                "Dungarees",
                "Hoodies",
                "Jeans",
                "Jumpsuits & Playsuits",
                "Knitwear",
                "Leggings",
                "Lingerie & Underwear",
                "Maternity",
                "Nightwear",
                "Shorts",
                "Skirts",
                "Snow & Rainwear",
                "Socks & Tights",
                "Sportswear",
                "Suits & Blazers",
                "Sweatshirts",
                "Swimwear",
                "Tops & T-Shirts",
                "Trousers"
            };

            
            for (int i = 0; i < productNames.Length; i++)
            {
                context.Products.Add(new Product() { Name = productNames[i] });
            }

            context.SaveChanges();
        }
    }
}
