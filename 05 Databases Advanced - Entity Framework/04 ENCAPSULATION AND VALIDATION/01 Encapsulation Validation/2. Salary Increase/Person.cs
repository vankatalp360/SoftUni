namespace _2.Salary_Increase
{
    using System;

    class Person
    {
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
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("No FirstName");
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
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("No LastName");
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
                    throw new ArgumentException("No Age");
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
                if (value <= 0)
                {
                    throw new ArgumentException("No Salary");
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
            if (this.age<30)
            {
                bonus = bonus / 2;
            }
            this.Salary *= 1.0 + bonus/100;
        }

        public override string ToString()
        {
            return $"{this.firstName} {this.lastName} iget {this.salary:F2} leva";
        }
    }
}
