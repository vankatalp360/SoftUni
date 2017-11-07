using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {
        List<Department> departments = new List<Department>();

        int n = int.Parse(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            string[] input = Console.ReadLine().Split();
            string name = input[0];
            decimal salary = decimal.Parse(input[1]);
            string position = input[2];
            string department = input[3];

            Employee employee = new Employee(name, salary, position, department);

            if (input.Length == 5)
            {
                var isAge = int.TryParse(input[4], out int age);
                if (isAge)
                {
                    employee.Age = age;
                }
                else
                {
                    employee.Email = input[4];
                }
            }
            else if (input.Length == 6)
            {
                employee.Email = input[4];
                employee.Age = int.Parse(input[5]);

            }

            if (!departments.Exists(x => x.Name == department))
            {
                Department currentDept = new Department();
                currentDept.Name = department;
                currentDept.Employees = new List<Employee>();
                departments.Add(currentDept);
            }

            departments.Find(x => x.Name == department).Employees.Add(employee);
        }

        Department highestSalaryDept = departments.Aggregate((x, y) => x.AvgSalary > y.AvgSalary ? x : y);

        Console.WriteLine($"Highest Average Salary: {highestSalaryDept.Name}");
        foreach (var emp in highestSalaryDept.Employees.OrderByDescending(x=>x.Salary))
        {
            Console.WriteLine($"{emp.Name} {emp.Salary:f2} {emp.Email} {emp.Age}");
        }

    }
}