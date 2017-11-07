namespace _3.Validation_Data
{
    using System;

    class Person
    {
        private const double MinimumSalary = 460d;
        private const int MinimumNameLenght = 3;

        private string firstName;
        private string lastName;
        private int age;
        private double salary;

        public Person(string firstName, string lastName, int age, double salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value)||value.Length<3)
                {
                    throw new ArgumentException($"First name cannot be less than {MinimumNameLenght} symbols");
                }
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
                {
                    throw new ArgumentException($"Last name cannot be less than {MinimumNameLenght} symbols");
                }
                this.lastName = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Age cannot be zero or negative integer");
                }
                this.age = value;
            }
        }

        public double Salary
        {
            get
            {
                return salary;
            }
            set
            {
                if (value <460)
                {
                    throw new ArgumentException($"Salary cannot be less than {MinimumSalary} leva");
                }
                this.salary = value;
            }
        }

        public void IncreaseSalary(double bonus)
        {
            if (bonus <= 0)
            {
                throw new ArgumentException("No Bonus");
            }
            if (this.age < 30)
            {
                bonus = bonus / 2;
            }
            this.Salary *= 1.0 + bonus / 100;
        }

        public override string ToString()
        {
            return $"{this.firstName} {this.lastName} get {this.salary:F2} leva";
        }
    }
}
