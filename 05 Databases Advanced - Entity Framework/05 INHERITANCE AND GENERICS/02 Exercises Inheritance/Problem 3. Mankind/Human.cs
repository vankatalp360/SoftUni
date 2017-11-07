namespace Problem_3.Mankind
{
    using System;
    using System.Text;

    public class Human
    {
        private const int FirstNameMinLength = 4;
        private const int LastNameMinLength = 3;

        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (value.Length < FirstNameMinLength)
                {
                    throw new ArgumentException($"Expected length at least 4 symbols! Argument: firstName");
                }
                if (!char.IsUpper(value[0]))
                {
                    throw new ArgumentException($"Expected upper case letter! Argument: firstName");
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
                if (value.Length < LastNameMinLength)
                {
                    throw new ArgumentException($"Expected length at least 3 symbols! Argument: lastName ");
                }
                if (!char.IsUpper(value[0]))
                {
                    throw new ArgumentException($"Expected upper case letter! Argument: lastName");
                }

                this.lastName = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"First Name: {this.firstName}")
                .AppendLine($"Last Name: {this.lastName}");

            return sb.ToString();
        }
    }
}
