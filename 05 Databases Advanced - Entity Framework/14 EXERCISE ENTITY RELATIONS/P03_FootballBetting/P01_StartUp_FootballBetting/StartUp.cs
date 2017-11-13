namespace P01_StartUp_FootballBetting
{
    using Microsoft.EntityFrameworkCore;
    using P03_FootballBetting.Data;
    using System;

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
