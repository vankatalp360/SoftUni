namespace _5._Change_Town_Names_Casing
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    class StartUp
    {
        static void Main()
        {
            string countryName = ReadCountryName();

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
                    List<Town> towns = ReadTownsIntoTheCountry(countryName, connection, transaction);

                    UpdateTownsName(connection, transaction, towns);
                }
            }
            catch(Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine(ex.Message);
            }            
        }

        private static void UpdateTownsName(SqlConnection connection, SqlTransaction transaction, List<Town> towns)
        {
            int counter = 0;

            foreach (var town in towns)
            {
                string townName = town.Name;
                string townUpperName = town.Name.ToUpper();

                var updater = "UPDATE Towns SET Name = @townUpperName WHERE Name LIKE @townName";
                var cmd = new SqlCommand(updater, connection, transaction);
                cmd.Parameters.AddWithValue("@townUpperName", townUpperName);
                cmd.Parameters.AddWithValue("@townName", townName);

                var trans = cmd.Transaction;
                int count = cmd.ExecuteNonQuery();

                if (count > 0)
                {
                    counter += count;
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("No town names were affected.");
            }
            else
            {
                Console.WriteLine($"{counter} town names were affected.");
                Console.WriteLine($"[{string.Join(", ", towns)}]");
            }
            transaction.Rollback();
        }

        private static List<Town> ReadTownsIntoTheCountry(string countryName, SqlConnection connection, SqlTransaction transaction)
        {
            var query = "SELECT T.Id, T.Name FROM Towns AS T JOIN Countries AS C ON C.Id=T.CountryId WHERE C.Name LIKE @countryName";

            var command = new SqlCommand(query, connection, transaction);
            command.Parameters.AddWithValue("@countryName", countryName);

            var reader = command.ExecuteReader();

            List<Town> towns = new List<Town>();

            using (reader)
            {
                while (reader.Read())
                {
                    int townId = int.Parse(Convert.ToString(reader[0]));
                    string townName = Convert.ToString(reader[1]);
                    Town town = new Town()
                    {
                        Name = townName,
                        Id = townId
                    };
                    towns.Add(town);
                }
            }

            return towns;
        }

        private static string ReadCountryName()
        {
            string countryName;
            while (true)
            {
                Console.WriteLine("Please enter country name:");
                countryName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(countryName))
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

            return countryName;
        }

        public static int ExecuteCommand(string commandText, SqlConnection connection)
        {
            SqlCommand cmd = new SqlCommand(commandText, connection);
            return cmd.ExecuteNonQuery();
        }
    }
}
