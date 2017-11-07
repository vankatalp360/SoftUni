namespace Problem_3.Mankind
{
    using System;
    using System.Text;

    public class Worker : Human
    {
        private const decimal MinWeekSalary = 10;
        private const int MinWorkingHoursPerDay = 1;
        private const int MaxWorkingHoursPerDay = 12;

        private decimal salaryPerWeek;
        private double workHoursPerDay;

        public Worker(string firstName, string lastName, decimal salaryPerWeek, double workHoursPerDay)
            : base(firstName, lastName)
        {
            this.Salary = salaryPerWeek;
            this.WorkingHoursPerDay = workHoursPerDay;

        }

        public decimal Salary
        {
            get
            {
                return salaryPerWeek;
            }
            set
            {
                if (value <= MinWeekSalary)
                {
                    throw new ArgumentException($"Expected value mismatch! Argument: weekSalary");
                }
                this.salaryPerWeek = value;
            }
        }

        public double WorkingHoursPerDay
        {
            get
            {
                return workHoursPerDay;
            }
            set
            {
                if (value < MinWorkingHoursPerDay || value > MaxWorkingHoursPerDay)
                {
                    throw new ArgumentException($"Expected value mismatch! Argument: workHoursPerDay");
                }
                this.workHoursPerDay = value;
            }
        }

        public decimal CalculateSalaryPerHour()
        {
            return this.Salary / 5 / (decimal)this.workHoursPerDay;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(base.ToString())
                .AppendLine($"Week Salary: {this.salaryPerWeek:F2}")
                .AppendLine($"Hours per day: {this.workHoursPerDay:F2}")
                .AppendLine($"Salary per hour: {this.CalculateSalaryPerHour():F2}");

            return sb.ToString();
        }

        //public override string ToString()
        //{
        //    return $"First Name: {this.FirstName}" + Environment.NewLine +
        //        $"Last Name: {this.LastName}" + Environment.NewLine +
        //        $"Week Salary: {this.Salary:F2}" + Environment.NewLine +
        //        $"Hours per day: {this.WorkingHoursPerDay:F2}" + Environment.NewLine +
        //        $"Salary per hour: {CalculateSalaryPerHour():F2}";
        //}
    }
}
