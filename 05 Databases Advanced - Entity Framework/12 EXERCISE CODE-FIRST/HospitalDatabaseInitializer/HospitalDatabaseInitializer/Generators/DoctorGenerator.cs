namespace P01_HospitalDatabase.Generators
{
    using P01_HospitalDatabase;
    using P01_HospitalDatabase.Data.Models;
    using System;

    class DoctorGenerator
    {
        internal static void InitialDoctorSeed(HospitalContext context)
        {
            var doctorsNames = new string[]
            {
                "Ivan Ivanov",
                "Lyuba Petrova",
                "Ivan Kostov",
                "Kuncho Kunchov",
                "Stanislav Petkov",
                "Dragana Mirkovich"
            };

            var specialties = new string[]
            {
                "Cardiologists",
                "Dermatologists",
                "Anatomists",
                "Leprologists",
                "Surgeons",
            };

            var random = new Random();

            for (int i = 0; i < doctorsNames.Length; i++)
            {
                int randomNumber = random.Next(0, specialties.Length);

                context.Doctors.Add(new Doctor() { Name = doctorsNames[i] , Specialty= specialties [randomNumber] });
            }

            context.SaveChanges();
        }

        public static void Generate(string doctorsName,string specialty, HospitalContext context)
        {
            context.Doctors.Add(new Doctor() { Name = doctorsName , Specialty=specialty });
        }
    }
}
