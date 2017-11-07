namespace _6._Remove_Villain
{
    using System;
    using System.Data.SqlClient;

    class StartUp
    {
        static void Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());

            if (villainId < 1)
            {
                throw new ArgumentException($"ID shound be positive. Can't use this ID:{villainId}.");
            }

            SqlConnection connection = new SqlConnection(
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
                    Villain villain = FindVillain(villainId, connection, transaction);

                    DeleteFromMinionsVillains(villain, connection, transaction);

                    DeleteFromVillains(villain, connection, transaction);
                }

                //transaction.Commit(); --in case you want to save changes use it
            }
            catch (ArgumentException e)
            {
                transaction.Rollback();
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                transaction.Rollback();
                Console.WriteLine(e.Message);
            }
        }

        private static void DeleteFromVillains(Villain villain, SqlConnection connection, SqlTransaction transaction)
        {
            var query = "DELETE FROM Villains WHERE Id = @villainId";
            SqlCommand command = new SqlCommand(query, connection, transaction);
            command.Parameters.AddWithValue("@villainId", villain.Id);

            int affectedRows = command.ExecuteNonQuery();

            if(affectedRows!=1)
            {
                throw new ArgumentException($"There are more than one villain with this ID:{villain.Id}");
            }

            Console.WriteLine($"{villain.Name} was deleted.");
        }

        private static void DeleteFromMinionsVillains(Villain villain, SqlConnection connection, SqlTransaction transaction)
        {
            var query = "DELETE FROM MinionsVillains WHERE VillainId = @villainId";
            SqlCommand command = new SqlCommand(query, connection, transaction);
            command.Parameters.AddWithValue("@villainId", villain.Id);

            int affectedRows = command.ExecuteNonQuery();

            Console.WriteLine($"{affectedRows} minions were released.");
        }

        private static Villain FindVillain(int villainId, SqlConnection connection, SqlTransaction transaction)
        {
            var query = "SELECT Id, Name FROM Villains WHERE Id = @villainId";
            SqlCommand command = new SqlCommand(query, connection, transaction);
            command.Parameters.AddWithValue("@villainId", villainId);

            var reader = command.ExecuteReader();

            using (reader)
            {
                int counter = 0;

                string Name = null;
                int Id = 0;

                while (reader.Read())
                {
                    counter++;
                    bool result = int.TryParse(Convert.ToString(reader[0]), out Id);
                    if (!result)
                    {
                        throw new ArgumentException("No such villain was found.");
                    }
                    Name = Convert.ToString(reader[1]);
                }

                if (counter != 1)
                {
                    throw new ArgumentException($"More than one villain with this ID {villainId} found.");
                }

                Villain villain = new Villain() { Name = Name, Id = Id };

                return villain;
            }
        }
    }
}
