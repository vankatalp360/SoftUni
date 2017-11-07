using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace _8._Increase_Minion_Age
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] minionIds = Console.ReadLine().
                Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries).
                Select(x => Convert.ToInt32(x)).
                ToArray();

            SqlConnection connection = new SqlConnection(
                "Server=.\\SQLEXPRESS;" +
                   "Database = MinionsDB;" +
                   "Integrated security=true"
                   );

            connection.Open();

            SqlTransaction tra = connection.BeginTransaction();

            try
            {
                using (connection)
                {
                    foreach (var minionId in minionIds)
                    {
                        ModifyMinion(minionId, connection,tra);
                    }

                    tra.Commit();

                    PrintResult(connection);
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

        private static void PrintResult(SqlConnection connection)
        {
            var query = "SELECT Name, Age FROM Minions";
            SqlCommand command = new SqlCommand(query, connection);

            var reader = command.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    string name = Convert.ToString(reader[0]);
                    int age;
                    bool hasAge = int.TryParse(Convert.ToString(reader[1]), out age);

                    Console.WriteLine($"{name} {age}");
                }
            }
        }

        private static void ModifyMinion(int minionId, SqlConnection connection , SqlTransaction tra)
        {
            SqlCommand commandName = SelectNameCommand(minionId, connection, tra);

            var readerName = commandName.ExecuteScalar();

            SqlCommand commandAge = SelectAgeCommand(minionId, connection, tra);

            var readerAge = commandAge.ExecuteScalar();

            string name;
            int age;

            CreateNewNameAndAge(readerName, readerAge, out name, out age);

            UpdateNameAndAge(minionId, name, age, connection, tra);
        }

        private static void UpdateNameAndAge(int minionId, string name, int age, SqlConnection connection, SqlTransaction tra)
        {
            var query = "UPDATE Minions SET Name = @name , Age=@age WHERE Id = @minionId";
            SqlCommand command = new SqlCommand(query, connection,tra);
            command.Parameters.AddWithValue("@minionId", minionId);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@age", age);

            var affectedRows = command.ExecuteNonQuery();

            if (affectedRows != 1)
            {
                tra.Rollback();
                throw new ArgumentException("Incorect transaction");
            }
        }

        private static void CreateNewNameAndAge(object readerName, object readerAge, out string name, out int age)
        {
            name = Convert.ToString(readerName);
            bool hasAge = int.TryParse(Convert.ToString(readerAge), out age);

            if (hasAge)
            {
                age++;
            }
            if (!string.IsNullOrWhiteSpace(name))
            {
                name = ChangeNameTitleCase(name);
            }
        }

        private static SqlCommand SelectAgeCommand(int minionId, SqlConnection connection, SqlTransaction tra)
        {
            var query = "SELECT Age FROM MInions WHERE Id = @minionId";
            SqlCommand command = new SqlCommand(query, connection,tra);
            command.Parameters.AddWithValue("@minionId", minionId);
            return command;
        }

        private static SqlCommand SelectNameCommand(int minionId, SqlConnection connection, SqlTransaction tra)
        {
            var query = "SELECT Name FROM MInions WHERE Id = @minionId";
            SqlCommand command = new SqlCommand(query, connection,tra);
            command.Parameters.AddWithValue("@minionId", minionId);
            return command;
        }

        private static string ChangeNameTitleCase(string name)
        {
            List<char> letters = name.ToList();

            char first = Char.ToUpper(letters[0]);

            name = first + name.Remove(0, 1);

            return name;
        }
    }
}
