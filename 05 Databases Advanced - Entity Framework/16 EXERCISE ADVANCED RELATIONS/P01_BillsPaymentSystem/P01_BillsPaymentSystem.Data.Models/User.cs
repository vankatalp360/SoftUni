namespace P01_BillsPaymentMethodsystem.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class User
    {
        private string firstName;
        private string lastName;
        private string email;
        private string password;

        public User()
        { }

        public User(string firstName, string lastName, string email, string password)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Password = password;
        }

        public int UserId { get; set; }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("User first name should be not emplty or whitespace.");
                }
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("User last name should be not emplty or whitespace.");
                }
                this.lastName = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("User email should be not emplty or whitespace.");
                }
                this.email = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("User password should be not emplty or whitespace.");
                }
                this.password = value;
            }
        }

        public ICollection<PaymentMethod> PaymentMethods { get; private set; } = new List<PaymentMethod>();
    }
}
