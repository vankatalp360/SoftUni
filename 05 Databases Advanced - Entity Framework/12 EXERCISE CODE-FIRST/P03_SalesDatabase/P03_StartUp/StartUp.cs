namespace P03_StartUp
{
    using P03_SaleDatabaseInitializer;
    using P03_SalesDatabase;
    using P03_SalesDatabase.Data;
    using P03_SalesDatabase.Data.Models;

    class StartUp
    {
        static void Main()
        {
            DatabaseInitializer.ResetDatabase();

            using (var context = new SalesContext())
            {

            }
        }
    }
}
