namespace StudentSystemStartUp
{
    using System;
    using P01_StudentSystem.Data;
    using Microsoft.EntityFrameworkCore;

    class StartUp
    {
        static void Main(string[] args)
        {
            var context = new StudentSystemContext();

            context.Database.EnsureDeleted();

            context.Database.Migrate();

            Console.WriteLine();
        }
    }
}
