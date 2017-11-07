using System;
using System.Data.SqlClient;

namespace _9._Age_Stored_Procedure
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int id = int.Parse(Console.ReadLine());

            SqlConnection connection = new SqlConnection(
                "Server=.\\SQLEXPRESS;" +
                   "Database = MinionsDB;" +
                   "Integrated security=true"
                   );

            connection.Open();

            SqlTransaction tran = connection.BeginTransaction();

            try
            {
                using (connection)
                {
                    var queryGetOlder = "EXEC usp_GetOlder @Id";
                    SqlCommand commandGetOlder = new SqlCommand(queryGetOlder, connection, tran);
                    commandGetOlder.Parameters.AddWithValue("@Id", id);

                    var affectedRows = commandGetOlder.ExecuteNonQuery();
                    if(affectedRows!=1)
                    {
                        throw new ArgumentException("Incorect transaction!");
                    }
                    tran.Commit();

                    var queryPrintResult = "SELECT Name,Age FROM Minions WHERE Id=@Id";
                    SqlCommand commandPrintResult = new SqlCommand(queryPrintResult, connection);
                    commandPrintResult.Parameters.AddWithValue("@Id", id);

                    var reader = commandPrintResult.ExecuteReader();

                    string name=null;
                    string age=null;
                    
                    while (reader.Read())
                    {
                        name = Convert.ToString(reader[0]);
                        age=Convert.ToString(reader[1]);
                    }
                    Console.WriteLine($"{name} – {age} years old");
                }

            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
