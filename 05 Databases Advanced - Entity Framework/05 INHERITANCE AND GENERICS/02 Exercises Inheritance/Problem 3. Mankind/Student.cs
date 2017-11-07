namespace Problem_3.Mankind
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Student : Human
    {
        private string facultyNumber;

        public Student(string fisrtName, string lastName, string facultyNumber)
            : base(fisrtName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get
            {
                return facultyNumber;
            }
            set
            {
                if (value.Length < 5 || value.Length > 10 || value.Any(x => !char.IsLetterOrDigit(x)))
                {
                    throw new ArgumentException("Invalid faculty number!");
                }

                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(base.ToString())
                .AppendLine($"Faculty number: {this.facultyNumber}");

            return sb.ToString();
        }

        //public override string ToString()
        //{
        //    return $"First Name: {this.FirstName}" + Environment.NewLine +
        //        $"Last Name: {this.LastName}" + Environment.NewLine +
        //        $"Faculty number: {this.FacultyNumber}";
        //}
    }
}
