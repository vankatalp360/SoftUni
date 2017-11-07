namespace P02_DatabaseFirst
{
    using Microsoft.EntityFrameworkCore;
    using P02_DatabaseFirst.Data;
    using P02_DatabaseFirst.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    class StartUp
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");

            using (var context = new SoftUniContext())
            {
                //Remove_Towns(context); //--15.

                //Delete_Project_by_Id(context); //--14.

                //Find_Employees_by_First_Name_Starting_With_Sa(context); //--13.

                //Increase_Salaries(context); //--12.

                //Find_Latest_10_Projects(context); //--11.

                //Departments_with_More_Than_5_Employees(context); //--10.

                //Employee_147(context); //--09.

                //Addresses_by_Town(context); //--08.

                //Employees_and_Projects(context); //--07.

                //Adding_a_New_Address_and_Updating_Employee(context); //--06.

                //Employees_from_Research_and_Development(context); //--05.

                //Employees_with_Salary_Over_50_000(context); //--04.

                //Employees_Full_Information(context); //--03.
            }
        }

        private static void Remove_Towns(SoftUniContext context)
        {
            string townName = Console.ReadLine();

            var town = context
                .Towns
                .SingleOrDefault(t => t.Name == townName);

            var addresses = context
                .Addresses
                .Where(a => a.TownId == town.TownId);

            int addressCount = addresses.Count();

            foreach (var address in addresses)
            {
                var employees = context
                    .Employees
                    .Where(e => e.AddressId == address.AddressId);
                foreach (var employee in employees)
                {
                    employee.AddressId = null;
                }
                context.Addresses.Remove(address);
            }

            context.Towns.Remove(town);

            Console.WriteLine($"{addressCount} address in {townName} was deleted");

            context.SaveChanges();
        }

        private static void Find_Employees_by_First_Name_Starting_With_Sa(SoftUniContext context)
        {
            var employees = context
                                .Employees
                                .Where(e => e.FirstName[0] == 'S' && e.FirstName[1] == 'a')
                                .Select(e => new
                                {
                                    e.FirstName,
                                    e.LastName,
                                    e.JobTitle,
                                    e.Salary
                                })
                                .OrderBy(e => e.FirstName)
                                .ThenBy(e => e.LastName);
            foreach (var e in employees)
            {
                Console.WriteLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
            }
        }

        private static void Delete_Project_by_Id(SoftUniContext context)
        {
            var projectId = 2;

            var empro = context
                .EmployeesProjects
                .Where(ep => ep.ProjectId == projectId);

            foreach (var ep in empro)
            {
                context.EmployeesProjects.Remove(ep);
            }

            var project = context.Projects.SingleOrDefault(p => p.ProjectId == projectId);

            context.Projects.Remove(project);

            context.SaveChanges();

            var projectNames = context
                .Projects
                .Select(p => p.Name)
                .Take(10);

            foreach (var pn in projectNames)
            {
                Console.WriteLine(pn);
            }
        }

        private static void Employee_147(SoftUniContext context)
        {
            var employee = context
                                .Employees
                                .Where(e => e.EmployeeId == 147)
                                .Select(e => new
                                {
                                    Name = $"{e.FirstName} {e.LastName}",
                                    e.JobTitle,
                                    Projects = e.EmployeesProjects.Select(ep => new
                                    {
                                        ep.Project.Name
                                    })
                                })
                                .ToList();

            foreach (var e in employee)
            {
                Console.WriteLine($"{e.Name} - {e.JobTitle}");

                foreach (var p in e.Projects.OrderBy(p => p.Name))
                {
                    Console.WriteLine(p.Name);
                }
            }
        }

        private static void Employees_and_Projects(SoftUniContext context)
        {
            var employees = context
                                .Employees
                                .Where(e => e.EmployeesProjects.Any(ep =>
                                ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                                .Select(e => new
                                {
                                    Name = $"{e.FirstName} {e.LastName}",
                                    ManagerName = $"{e.Manager.FirstName} {e.Manager.LastName}",
                                    Projects = e.EmployeesProjects.Select(ep => new
                                    {
                                        ep.Project.Name,
                                        ep.Project.StartDate,
                                        ep.Project.EndDate
                                    })
                                })
                                .Take(30);

            foreach (var e in employees)
            {
                Console.WriteLine($"{e.Name} - Manager: {e.ManagerName}");

                foreach (var p in e.Projects)
                {
                    Console.WriteLine($"--{p.Name} - {ConvertDate(p.StartDate)} - {ConvertDate(p.EndDate)}");
                }
            }
        }

        private static string ConvertDate(DateTime? date)
        {
            if (date == null)
            {
                return "not finished";
            }

            return date.Value.ToString("M/d/yyyy h:mm:ss tt");
        }

        private static void Increase_Salaries(SoftUniContext context)
        {
            var depNames = new string[] { "Engineering", "Tool Design", "Marketing", "Information Services" };
            var employees = context
                            .Employees
                            .Where(e => Array.IndexOf(depNames, e.Department.Name) > -1);

            foreach(var e in employees)
            {
                e.Salary *= 1.12m;
            }
            context.SaveChanges();

            foreach (var e in employees.OrderBy(e => e.FirstName)
                            .ThenBy(e => e.LastName))
            {
                Console.WriteLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
            }
        }

        private static void Find_Latest_10_Projects(SoftUniContext context)
        {
            var projects = context
                                .Projects
                                .Select(p => new
                                {
                                    p.Name,
                                    p.Description,
                                    p.StartDate
                                })
                                .OrderByDescending(p => p.StartDate)
                                .Take(10)
                                .OrderBy(p => p.Name)
                                .ToList();

            foreach (var p in projects)
            {
                Console.WriteLine(p.Name);
                Console.WriteLine(p.Description);
                Console.WriteLine(p.StartDate.ToString("M/d/yyyy h:mm:ss tt"));
            }
        }

        private static void Departments_with_More_Than_5_Employees(SoftUniContext context)
        {
            var departments = context
                                .Departments
                                .Include(d => d.Employees)
                                .Select(d => new
                                {
                                    d.Name,
                                    d.Manager,
                                    d.Employees
                                })
                                .Where(d => d.Employees.Count() > 5)
                                .OrderBy(d => d.Employees.Count())
                                .ThenBy(d => d.Name)
                                .ToList();

            foreach (var d in departments)
            {
                Console.WriteLine($"{d.Name} - {d.Manager.FirstName} {d.Manager.LastName}");

                foreach (var e in d.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
                {
                    Console.WriteLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                }
                Console.WriteLine("----------");
            }
        }

        private static void Addresses_by_Town(SoftUniContext context)
        {
            var adresses = context
                                .Addresses
                                .Include(a => a.Employees)
                                .Include(a => a.Town)
                                .OrderByDescending(a => a.Employees.Count())
                                .ThenBy(a => a.Town.Name)
                                .ThenBy(a => a.AddressText)
                                .Take(10)
                                .ToList();
            foreach (var a in adresses)
            {
                Console.WriteLine($"{a.AddressText}, {a.Town.Name} - {a.Employees.Count()} employees");
            }
        }

        private static void Adding_a_New_Address_and_Updating_Employee(SoftUniContext context)
        {
            var address = new Address() { AddressText = "Vitoshka 15", TownId = 4 };

            Employee employee = context
                .Employees
                .Include(e => e.Address)
                .SingleOrDefault(e => e.LastName == "Nakov");

            employee.Address = address;

            context.SaveChanges();

            var employeeAdressText = context
                .Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => new
                {
                    AddressText = e.Address.AddressText
                })
                .ToList();

            foreach (var text in employeeAdressText)
            {
                Console.WriteLine($"{text.AddressText}");
            }
        }

        private static void Employees_from_Research_and_Development(SoftUniContext context)
        {
            var employees = context
                                                       .Employees
                                                       .Include(e => e.Department)
                                                       .Where(e => e.Department.Name == "Research and Development")
                                                       .Select(e => new
                                                       {
                                                           e.FirstName,
                                                           e.LastName,
                                                           e.Department.Name,
                                                           e.Salary
                                                       })
                                                       .OrderBy(e => e.Salary)
                                                       .ThenByDescending(e => e.FirstName)
                                                       .ToList();

            foreach (var e in employees)
            {
                Console.WriteLine($"{e.FirstName} {e.LastName} from {e.Name} - ${e.Salary:f2}");
            }
        }

        private static void Employees_with_Salary_Over_50_000(SoftUniContext context)
        {
            var employees = context
                                            .Employees
                                            .Where(e => e.Salary > 50000)
                                            .Select(e => new
                                            {
                                                e.FirstName
                                            })
                                            .OrderBy(e => e.FirstName)
                                            .ToList();

            foreach (var e in employees)
            {
                Console.WriteLine($"{e.FirstName}");
            }
        }

        private static void Employees_Full_Information(SoftUniContext context)
        {
            var employees = context
                                .Employees
                                .Select(e => new
                                {
                                    e.FirstName,
                                    e.LastName,
                                    e.MiddleName,
                                    e.JobTitle,
                                    e.Salary,
                                    e.EmployeeId
                                })
                                .OrderBy(e => e.EmployeeId)
                                .ToList();

            foreach (var e in employees)
            {
                Console.WriteLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:F2}");
            }
        }
    }
}
