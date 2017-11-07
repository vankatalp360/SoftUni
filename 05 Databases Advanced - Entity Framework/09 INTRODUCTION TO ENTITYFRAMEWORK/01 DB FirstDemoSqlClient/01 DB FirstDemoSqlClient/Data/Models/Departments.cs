namespace _01_DB_FirstDemoSqlClient.Data.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Department
    {
        public Department()
        {
        }

        public int DepartmentId { get; set; }
        public string Name { get; set; }

        public int ManagerId { get; set; }
        public Employee Manager { get; set; }

        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
