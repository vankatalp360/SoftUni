using System.Collections.Generic;

public class Department
{
    private List<Employee> employees;

    public string Name { get; set; }
    public List<Employee> Employees
    {
        get
        {
            return employees;
        }
        set
        {
            employees = value;
        }
    }

    public decimal AvgSalary
    {
        get
        {
            return CalculateAvgSalary(employees);
        }
    }

    private decimal CalculateAvgSalary (List<Employee> employees)
    {
        if (employees.Count==0)
        {
            return 0;
        }
        decimal result = 0;
        foreach(var emp in employees)
        {
            result += emp.Salary;
        }

        return result / employees.Count;
    }
}