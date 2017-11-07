using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DB_Apps_Demo
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var connection = new SqlConnection(
                 "server=.\\SQLEXPRESS;Initial Catalog=SoftUni;Integrated Security=True");

            ReadDBTables(connection);

            connection = new SqlConnection(
                 "server=.\\SQLEXPRESS;Initial Catalog=SoftUni;Integrated Security=True");

            ReadTableInfoInDB(connection);

            connection = new SqlConnection(
                 "server=.\\SQLEXPRESS;Initial Catalog=SoftUni;Integrated Security=True");
            ReadColumnNamesInEmployees(connection);

            connection = new SqlConnection(
                 "server=.\\SQLEXPRESS;Initial Catalog=SoftUni;Integrated Security=True");

            InsertIntoTownsNewTown(connection);

            connection = new SqlConnection(
                 "server=.\\SQLEXPRESS;Initial Catalog=SoftUni;Integrated Security=True");

            ReadEmployeesFromTable(connection);
        }

        private static void ReadDBTables(SqlConnection connection)
        {
            connection.Open();
            using (connection)
            {
                var command = new SqlCommand(
                    "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES", connection);

                var tableCount = (int)command.ExecuteScalar();

                Console.WriteLine($"INFO SCHEMA TABLE COUNT:{tableCount}");
            }
        }

        private static void ReadTableInfoInDB(SqlConnection connection)
        {
            connection.Open();
            using (connection)
            {
                var command = new SqlCommand("SELECT * FROM INFORMATION_SCHEMA.TABLES", connection);

                var reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("Table/View Name:{0}", reader.GetValue(2));
                    }
                }
            }
        }

        private static void ReadColumnNamesInEmployees(SqlConnection connection)
        {
            connection.Open();
            using (connection)
            {
                var command = new SqlCommand("SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Employees' ", connection);

                var reader = command.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["COLUMN_NAME"]);
                    }
                }
            }
        }

        private static void ReadEmployeesFromTable(SqlConnection connection)
        {
            connection.Open();
            using (connection)
            {
                var command = new SqlCommand("SELECT FirstName, LastName, JobTitle FROM Employees", connection);

                var reader = command.ExecuteReader();

                List<Employee> employees = new List<Employee>();

                using (reader)
                {
                    while (reader.Read())
                    {
                        var firstName = (string)reader["FirstName"];
                        var lastName = (string)reader["LastName"];
                        var jobTitle = (string)reader["JobTitle"];

                        Employee employee = new Employee()
                        {
                            firstName = firstName,
                            lastName = lastName,
                            jobTitle = jobTitle
                        };

                        employees.Add(employee);
                    }
                }
                GroupEmploees(employees);
            }
        }

        private static void GroupEmploees(List<Employee> employees)
        {
            var groupedEmployees = employees.GroupBy(x => x.jobTitle).OrderByDescending(t => t.Count());

            foreach (var group in groupedEmployees)
            {
                Console.WriteLine($"--Job Title:{group.Key} / Count:{group.Count()} / Emploeeys:");
                foreach (var employee in group)
                {
                    Console.WriteLine(employee);
                }
            }
        }

        private static void InsertIntoTownsNewTown(SqlConnection connection)
        {
            connection.Open();
            using (connection)
            {
                var transaction = connection.BeginTransaction();
                var cmd = new SqlCommand("INSERT INTO Towns (Name) VALUES (@TownName)", connection, transaction);
                Console.WriteLine("Please write new Town name:");
                string townName = Console.ReadLine();
                cmd.Parameters.AddWithValue("@TownName", townName);
                cmd.ExecuteNonQuery();
                transaction.Rollback();
            }
        }
    }
}
