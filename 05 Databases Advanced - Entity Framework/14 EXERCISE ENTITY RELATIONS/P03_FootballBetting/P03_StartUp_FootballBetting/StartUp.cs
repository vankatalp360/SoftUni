namespace P03_FootballBetting
{
    using System;
    using P03_FootballBetting.Data;
    using Microsoft.EntityFrameworkCore;

    class StartUp
    {
        static void Main(string[] args)
        {
            var context = new FootballBettingContext();

            context.Database.EnsureDeleted();

            context.Database.Migrate();

            Console.WriteLine();
        }
    }
}
