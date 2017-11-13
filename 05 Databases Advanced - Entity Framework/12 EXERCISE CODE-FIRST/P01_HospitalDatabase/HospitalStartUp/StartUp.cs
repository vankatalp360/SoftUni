namespace HospitalStartUp
{
    using P01_HospitalDatabase.Data.Models;
    using P01_HospitalDatabase.Data;
    using P01_HospitalDatabase;
    using P01_HospitalDatabase.Initializer;

    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            DatabaseInitializer.ResetDatabase();

            using (var context = new HospitalContext())
            {

            }
        }
    }
}
