namespace _3._Minion_Names
{
    using System;
    using System.Data.SqlClient;

    class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Please enter villian ID:");
                int villinaId = int.Parse(Console.ReadLine());

                if (villinaId <= 0)
                {
                    throw new ArgumentException("Villian ID can not be negative or zero!!!");
                }

                var connection = new SqlConnection(
                    "Server=.\\SQLEXPRESS;" +
                    "Database = MinionsDB;" +
                    "Integrated security=true"
                    );

                connection.Open();

                using (connection)
                {
                    var query = "SELECT Name " +
                                "FROM Villains AS V " +
                                "WHERE Id=@villinaId";

                    var command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@villinaId", villinaId);

                    string villianName = Convert.ToString(command.ExecuteScalar());

                    if(string.IsNullOrWhiteSpace(villianName))
                    {
                        throw new ArgumentException($"No villain with ID {villinaId} exists in the database.");
                    }

                    Console.WriteLine($"Villain: {villianName}");

                    query = "SELECT M.Name AS [MinionName], M.Age AS [Age] " +
                            "FROM Minions AS M " +
                            "JOIN MinionsVillains AS MV " +
                            "ON MV.MinionId=M.Id " +
                            "WHERE MV.VillainId=@villinaId";

                    command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@villinaId", villinaId);

                    var reader = command.ExecuteReader();

                    using (reader)
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("(no minions)");
                        }
                        else
                        {
                            int counter = 1;

                            while (reader.Read())
                            {
                                string minionName = Convert.ToString(reader[0]);
                                int age;
                                bool hasAge = int.TryParse(Convert.ToString(reader[1]),out age);
                                if(!hasAge)
                                {
                                    Console.WriteLine($"{counter}. {minionName} (no specified age)");
                                }
                                else
                                {
                                    Console.WriteLine($"{counter}. {minionName} {age}");
                                }
                                counter++;
                            }
                        }
                    }
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
