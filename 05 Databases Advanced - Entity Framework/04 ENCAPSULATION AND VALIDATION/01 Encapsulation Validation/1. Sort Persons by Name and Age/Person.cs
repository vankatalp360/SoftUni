namespace _1.Sort_Persons_by_Name_and_Age
{
    using System;

    class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
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
                if (value<=0)
                {
                    throw new ArgumentException("No Age");
                }
                this.age = value;
            }
        }

        public override string ToString()
        {
            return $"{this.firstName} {this.lastName} is a {this.age} years old";
        }
    }
}
