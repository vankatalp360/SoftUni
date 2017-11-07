using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main(string[] args)
    {
        Dictionary<string, List<Employee>> departments = new Dictionary<string, List<Employee>>();
        int n = int.Parse(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            string[] input = Console.ReadLine().Split().ToArray();
            string name = input[0];
            decimal salary = decimal.Parse(input[1]);
            string position = input[2];
            string department = input[3];
            Employee employee = new Employee(name, salary, position, department);
            if (input.Length == 5)
            {
                var isAge = int.TryParse(input[4], out int age);
                if(isAge)
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
            if(!departments.ContainsKey(department))
            {
                departments[department] = new List<Employee>();
            }
            departments[department].Add(employee);
        }
        decimal highestAvgSalary = 0;
        string highestSalaryDep="";
        foreach(var dep in departments)
        {
            decimal depTotalSalary = 0;
            foreach(var emp in dep.Value)
            {
                depTotalSalary += emp.Salary;
            }
            int empCount = dep.Value.Count;
            decimal avgSalary = depTotalSalary / empCount;

            if(avgSalary>highestAvgSalary)
            {
                highestAvgSalary = avgSalary;
                highestSalaryDep = dep.Key;
            }
        }
        Console.WriteLine($"Highest Average Salary: {highestSalaryDep}");
        foreach(var emp in departments[highestSalaryDep].OrderByDescending(e=>e.Salary))
        {
            Console.WriteLine($"{emp.Name} {emp.Salary:f2} {emp.Email} {emp.Age}");
        }
    }
}
