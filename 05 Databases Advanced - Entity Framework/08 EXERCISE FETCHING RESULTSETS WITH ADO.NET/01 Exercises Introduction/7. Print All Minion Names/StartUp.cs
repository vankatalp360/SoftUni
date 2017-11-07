namespace _7._Print_All_Minion_Names
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    class StartUp
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(
                           "Server=.\\SQLEXPRESS;" +
                              "Database = MinionsDB;" +
                              "Integrated security=true"
                              );

            connection.Open();

            List<string> minionNames = new List<string>();
            try
            {
                ReadMinionNames(connection, minionNames);

                PrintMinionNames(minionNames);

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

        private static void PrintMinionNames(List<string> minionNames)
        {
            int lenght = minionNames.Count;
            for (int i = 0; i <= lenght  / 2; i++)
            {
                Console.WriteLine(minionNames[i]);
                if (i < lenght -1-i)
                {
                    Console.WriteLine(minionNames[lenght - i-1]);
                }
            }
        }

        private static void ReadMinionNames(SqlConnection connection, List<string> minionNames)
        {
            using (connection)
            {
                var query = "SELECT Name FROM Minions";
                SqlCommand command = new SqlCommand(query, connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string Name = Convert.ToString(reader[0]);
                    minionNames.Add(Name);
                }
            }
        }
    }
}
