namespace _01_DB_FirstDemoSqlClient
{
    using System;
    using _01_DB_FirstDemoSqlClient.Data;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            using (var context = new SoftUniDbContext())
            {
                var employees = context.Employees
                    .Select(e => new
                    {
                        e.FirstName,
                        e.EmployeesProjects.Count
                    })
               .Where(x => x.Count >= 2)
               .OrderByDescending(x => x.Count)
               .ToList();

                foreach (var employee in employees)
                {
                    Console.WriteLine($"{employee.FirstName} / {employee.Count}"); ;
                }
            }
        }
    }
}
