using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2017._05._22___PF___Employee_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            string Name = Console.ReadLine();
            int Age = int.Parse(Console.ReadLine());
            int EmployeeID = int.Parse(Console.ReadLine());
            double MonthlySalary= double.Parse(Console.ReadLine());
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Employee ID: {EmployeeID:D8}");
            Console.WriteLine($"Salary: {MonthlySalary:F2}");
        }
    }
}
