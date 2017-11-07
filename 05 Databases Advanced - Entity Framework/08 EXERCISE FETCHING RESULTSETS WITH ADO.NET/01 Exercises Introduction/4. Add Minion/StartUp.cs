namespace _4._Add_Minion
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    class StartUp
    {
        static void Main()
        {
            const string evilnessName = "Evil";
            try
            {
                string minionName, townName, countryName;
                int minionAge;
                ReadMinion(out minionName, out minionAge, out townName, out countryName);

                string VillainName = ReadVillainName();
                Console.WriteLine("Data:");
                Console.WriteLine($"Minion:{minionName}\r\nMinion Age:{minionAge}\r\nTown Name:{townName}\r\nCountry Name:{countryName}\r\nVillain Name:{VillainName}");
                Console.WriteLine("-------------------------");
                var connection = new SqlConnection(
                   "Server=.\\SQLEXPRESS;" +
                   "Database = MinionsDB;" +
                   "Integrated security=true"
                   );

                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    using (connection)
                    {
                        Country country = SelectCountry(countryName, connection, transaction);

                        if (country.Id == 0 || country.Name == null)
                        {
                            InsertNewCountry(countryName,  connection, transaction);
                            country = SelectCountry(countryName, connection, transaction);
                        }

                        Town town = SelectTown(townName, country.Id, connection, transaction);

                        if (town.Id == 0 || town.Name == null)
                        {
                            InsertNewTown(townName, country.Id, connection, transaction);
                            town = SelectTown(townName, country.Id,connection, transaction);
                        }

                        EvilnessFactor evilnessFactor = SelectEvilnessFactor(evilnessName, connection,transaction);

                        if (evilnessFactor.Id == 0 || evilnessFactor.Name == null)
                        {
                            InsertNewEvilness(evilnessName,connection, transaction);
                            evilnessFactor = SelectEvilnessFactor(evilnessName, connection, transaction);
                        }

                        Villain Villain = SelectVillains(VillainName, evilnessFactor.Id, connection, transaction);

                        if (Villain.Id == 0 || Villain.Name == null)
                        {
                            InsertNewVillain(VillainName, evilnessFactor.Id, connection, transaction);
                            Villain = SelectVillains(VillainName, evilnessFactor.Id, connection, transaction);
                        }

                        Minion minion = SelectMinion(minionName, minionAge, town.Id , connection, transaction);

                        if (minion.Id == 0 || minion.Name == null)
                        {
                            InsertNewMinion(minionName,minionAge,town.Id, connection, transaction);
                            minion = SelectMinion(minionName, minionAge, town.Id, connection, transaction);
                        }

                        MinionsVillains minionsVillains = SelectMinionsVillains(minion.Id, Villain.Id, connection, transaction);

                        if (minionsVillains.MinionId == 0 || minionsVillains.VillainId == 0)
                        {
                            InsertNewMinionVillain(minion, Villain, connection, transaction);
                            minionsVillains = SelectMinionsVillains(minion.Id, Villain.Id, connection, transaction);
                        }
                        transaction.Commit();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                    transaction.Rollback();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void InsertNewMinionVillain(Minion minion, Villain Villain, SqlConnection connection, SqlTransaction transaction)
        {
            var insertNewMilionVillain = "INSERT INTO MinionsVillains (MinionId , VillainId) VALUES (@MinionId,@VillainId)";

            var commandMinionVillain = new SqlCommand(insertNewMilionVillain, connection, transaction);
            commandMinionVillain.Parameters.AddWithValue("@MinionId", minion.Id);
            commandMinionVillain.Parameters.AddWithValue("@VillainId", Villain.Id);

            int affectedRows = commandMinionVillain.ExecuteNonQuery();

            if (affectedRows != 1)
            {
                throw new Exception("Invalide transaction.");
            }
            Console.WriteLine($"Successfully added {minion.Name} to be minion of {Villain.Name}.");
        }

        private static MinionsVillains SelectMinionsVillains(int MinionId, int VillainId, SqlConnection connection, SqlTransaction transaction)
        {
            var selectMinionVillain = "SELECT TOP(1) MinionId,VillainId FROM MinionsVillains WHERE  MinionId = @MinionId AND VillainId=@VillainId";
            var commandMinion = new SqlCommand(selectMinionVillain, connection, transaction);
            commandMinion.Parameters.AddWithValue("@MinionId", MinionId);
            commandMinion.Parameters.AddWithValue("@VillainId", VillainId);

            var reader = commandMinion.ExecuteReader();
            MinionsVillains minionVillain = new MinionsVillains();

            using (reader)
            {
                while (reader.Read())
                {
                    int minionId = int.Parse(Convert.ToString(reader[0]));
                    minionVillain.MinionId = minionId;
                    int villainId = int.Parse(Convert.ToString(reader[1]));
                    minionVillain.VillainId = villainId;
                }
            }

            return minionVillain;
        }

        private static void InsertNewMinion(string minionName, int minionAge, int TownId, SqlConnection connection, SqlTransaction transaction)
        {
            var insertNewMinion = "INSERT INTO Minions (Name , Age, TownId) VALUES (@minionName,@Age,@TownId)";

            var commandVillain = new SqlCommand(insertNewMinion, connection, transaction);
            commandVillain.Parameters.AddWithValue("@minionName", minionName);
            commandVillain.Parameters.AddWithValue("@Age", minionAge);
            commandVillain.Parameters.AddWithValue("@TownId", TownId);

            int affectedRows = commandVillain.ExecuteNonQuery();

            if (affectedRows != 1)
            {
                throw new Exception("Invalide transaction.");
            }
            Console.WriteLine($"Milion {minionName} was added to the database.");
        }

        private static Minion SelectMinion(string minionName, int minionAge, int TownId, SqlConnection connection, SqlTransaction transaction)
        {
            var selectMinion = "SELECT TOP(1) Id,Name,Age,TownId FROM Minions WHERE Name LIKE @minionName AND Age = @minionAge AND TownId=@TownId";
            var commandMinion = new SqlCommand(selectMinion, connection, transaction);
            commandMinion.Parameters.AddWithValue("@minionName", minionName);
            commandMinion.Parameters.AddWithValue("@minionAge", minionAge);
            commandMinion.Parameters.AddWithValue("@TownId", TownId);

            var reader = commandMinion.ExecuteReader();
            Minion minion = new Minion();

            using (reader)
            {
                while (reader.Read())
                {
                    int minionId = int.Parse(Convert.ToString(reader[0]));
                    minion.Id = minionId;
                    minion.Name = minionName;
                    minion.Age = minionAge;
                    minion.TownId = TownId;
                }
            }

            return minion;
        }

        private static void InsertNewVillain(string VillainName, int EvilnessFactorId, SqlConnection connection, SqlTransaction transaction)
        {
            var insertNewVillain = "INSERT INTO Villains (Name , EvilnessFactorId) VALUES (@VillainName,@EvilnessFactorId)";

            var commandVillain = new SqlCommand(insertNewVillain, connection, transaction);
            commandVillain.Parameters.AddWithValue("@VillainName", VillainName);
            commandVillain.Parameters.AddWithValue("@EvilnessFactorId", EvilnessFactorId);

            int affectedRows = commandVillain.ExecuteNonQuery();

            if (affectedRows != 1)
            {
                throw new Exception("Invalide transaction.");
            }
            Console.WriteLine($"Villain {VillainName} was added to the database.");
        }

        private static Villain SelectVillains(string VillainName, int EvilnessFactorId, SqlConnection connection, SqlTransaction transaction)
        {
            var selectVillain = "SELECT TOP(1) Id,Name, EvilnessFactorId FROM Villains WHERE Name LIKE @VillainName AND EvilnessFactorId=@EvilnessFactorId";
            var commandVillain = new SqlCommand(selectVillain, connection, transaction);
            commandVillain.Parameters.AddWithValue("@VillainName", VillainName);
            commandVillain.Parameters.AddWithValue("@EvilnessFactorId", EvilnessFactorId);

            var reader = commandVillain.ExecuteReader();
            Villain Villain = new Villain();

            using (reader)
            {
                while (reader.Read())
                {
                    int VillainId = int.Parse(Convert.ToString(reader[0]));
                    Villain.Id = VillainId;
                    Villain.Name = VillainName;
                    Villain.EvilnessFactorId = EvilnessFactorId;
                }
            }

            return Villain;
        }

        private static void InsertNewEvilness(string evilnessName, SqlConnection connection, SqlTransaction transaction)
        {
            var insertNewCountry = "INSERT INTO EvilnessFactor (Name) VALUES (@evilnessName)";

            var commandEvilness = new SqlCommand(insertNewCountry, connection, transaction);
            commandEvilness.Parameters.AddWithValue("@evilnessName", evilnessName);

            int affectedRows = commandEvilness.ExecuteNonQuery();

            if (affectedRows != 1)
            {
                throw new Exception("Invalide transaction.");
            }
            Console.WriteLine($"EvilnessFactor {evilnessName} was added to the database.");
        }

        private static EvilnessFactor SelectEvilnessFactor(string evilnessName, SqlConnection connection, SqlTransaction transaction)
        {
            var selectEvilness = "SELECT TOP(1) Id FROM EvilnessFactors WHERE Name LIKE @evilnessName";
            var commandCountry = new SqlCommand(selectEvilness, connection, transaction);
            commandCountry.Parameters.AddWithValue("@evilnessName", evilnessName);

            var reader = commandCountry.ExecuteReader();
            EvilnessFactor evilness = new EvilnessFactor();

            using (reader)
            {
                while (reader.Read())
                {
                    int countryId = int.Parse(Convert.ToString(reader[0]));
                    evilness.Name = evilnessName;
                    evilness.Id = countryId;
                }
            }

            return evilness;
        }

        private static void InsertNewCountry(string countryName, SqlConnection connection, SqlTransaction transaction)
        {
            var insertNewCountry = "INSERT INTO Countries (Name) VALUES (@countryName)";

            var commandTown = new SqlCommand(insertNewCountry, connection, transaction);
            commandTown.Parameters.AddWithValue("@countryName", countryName);

            int affectedRows = commandTown.ExecuteNonQuery();

            if (affectedRows != 1)
            {
                throw new Exception("Invalide transaction.");
            }

            Console.WriteLine($"Country {countryName} was added to the database.");
        }

        private static Country SelectCountry(string countryName, SqlConnection connection, SqlTransaction transaction)
        {
            var selectCountry = "SELECT TOP(1) Id FROM Countries WHERE Name LIKE @countryName";
            var commandCountry = new SqlCommand(selectCountry, connection, transaction);
            commandCountry.Parameters.AddWithValue("@countryName", countryName);

            var reader = commandCountry.ExecuteReader();
            Country country = new Country();

            using (reader)
            {

                while (reader.Read())
                {
                    int countryId = int.Parse(Convert.ToString(reader[0]));
                    country.Name = countryName;
                    country.Id = countryId;
                }
            }

            return country;
        }

        private static void InsertNewTown(string townName, int countryId, SqlConnection connection, SqlTransaction transaction)
        {
            var insertNewTown = "INSERT INTO Towns (Name, CountryId) VALUES (@townName,@countryId)";

            var commandTown = new SqlCommand(insertNewTown, connection, transaction);
            commandTown.Parameters.AddWithValue("@townName", townName);
            commandTown.Parameters.AddWithValue("@countryId", countryId);

            int affectedRows = commandTown.ExecuteNonQuery();

            if (affectedRows != 1)
            {
                throw new Exception("Invalide transaction.");
            }
            Console.WriteLine($"Town {townName} was added to the database.");
        }

        private static Town SelectTown(string townName, int countryId,  SqlConnection connection, SqlTransaction transaction)
        {
            var selectTown = "SELECT TOP(1) Id FROM Towns WHERE Name LIKE @townName AND CountryId = @countryId";
            var commandTown = new SqlCommand(selectTown, connection,transaction);
            commandTown.Parameters.AddWithValue("@townName", townName);
            commandTown.Parameters.AddWithValue("@countryId", countryId);

            var reader = commandTown.ExecuteReader();
            Town town = new Town();

            using (reader)
            {

                while (reader.Read())
                {
                    int townId = int.Parse(Convert.ToString(reader[0]));
                    town.Name = townName;
                    town.Id = townId;
                    town.CountryId = countryId;
                }
            }

            return town;
        }

        private static string ReadVillainName()
        {
            string VillainName;

            string[] VillainInfo;

            while (true)
            {
                Console.WriteLine("Please enter Villain:");

                VillainInfo = Console.ReadLine().Split();
                if (VillainInfo.Length != 1)
                {
                    Console.Clear();
                    Console.WriteLine("Villain name shound be not empty or whitespace.");
                }
                else
                {
                    VillainName = VillainInfo[0];

                    if (string.IsNullOrWhiteSpace(VillainName))
                    {
                        Console.Clear();
                        Console.WriteLine("Villain name shound be not empty or whitespace.");
                    }
                    else
                    {
                        Console.Clear();
                        break;
                    }
                }
            }

            return VillainName;
        }


        private static void ReadMinion(out string minionName, out int minionAge, out string minionTown, out string minionCountry
            )
        {
            string[] minionInfo;

            while (true)
            {
                Console.WriteLine("Please enter minion:");

                minionInfo = Console.ReadLine().Split();
                if (minionInfo.Length != 4)
                {
                    Console.Clear();
                    Console.WriteLine("Incorect input.");
                }
                else
                {
                    minionName = minionInfo[0];
                    bool checkAge = int.TryParse(minionInfo[1], out minionAge);
                    minionTown = minionInfo[2];
                    minionCountry = minionInfo[3];

                    if (string.IsNullOrWhiteSpace(minionName))
                    {
                        Console.Clear();
                        Console.WriteLine("Minion name shound be not empty or whitespace.");
                    }
                    else if (!checkAge)
                    {
                        Console.Clear();
                        Console.WriteLine("Incorect Age.");
                    }
                    else if (minionAge <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Age shouldn't be negative or zero.");
                    }
                    else if (string.IsNullOrWhiteSpace(minionTown))
                    {
                        Console.Clear();
                        Console.WriteLine("Town name shound be not empty or whitespace.");
                    }
                    else if (string.IsNullOrWhiteSpace(minionCountry))
                    {
                        Console.Clear();
                        Console.WriteLine("Country name shound be not empty or whitespace.");
                    }
                    else
                    {
                        Console.Clear();
                        break;
                    }
                }
            }
        }
    }
}
