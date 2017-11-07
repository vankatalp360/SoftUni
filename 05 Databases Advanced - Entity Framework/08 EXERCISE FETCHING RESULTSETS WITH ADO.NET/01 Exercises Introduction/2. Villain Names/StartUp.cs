namespace _2._Villain_Names
{
    using System;
    using System.Data.SqlClient;

    class StartUp
    {
        static void Main()
        {
            try
            {

                Console.Write("Please enter min number of minions value:");
                int value = int.Parse(Console.ReadLine());
                
                if(value<0)
                {
                    throw new ArgumentException("Number of minions can't be negative!!!");
                }

                var connection = new SqlConnection(
                    "Server=.\\SQLEXPRESS;" +
                    "Database = MinionsDB;" +
                    "Integrated security=true"
                    );

                connection.Open();

                using (connection)
                {
                    try
                    {
                        var query = "SELECT V.Name, COUNT(M.ID) AS [Count] " +
                                    "FROM MinionsVillains AS MV " +
                                    "JOIN Villains AS V " +
                                    "ON V.Id=MV.VillainId " +
                                    "JOIN Minions AS M " +
                                    "ON M.Id=MV.MinionId " +
                                    "GROUP BY V.ID, V.Name " +
                                    "HAVING COUNT(M.ID)>=@value " +
                                    "ORDER BY [Count] DESC";

                        SqlCommand cmd = new SqlCommand(query, connection);

                        cmd.Parameters.AddWithValue("@value", value);

                        var reader = cmd.ExecuteReader();

                        using (reader)
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    var villianName = (string)reader["Name"];
                                    var minionsCount = (int)reader["Count"];

                                    Console.WriteLine($"{villianName} - {minionsCount}");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"There is no villians with more than {value} minions!");
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            catch(ArgumentException ex)
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
