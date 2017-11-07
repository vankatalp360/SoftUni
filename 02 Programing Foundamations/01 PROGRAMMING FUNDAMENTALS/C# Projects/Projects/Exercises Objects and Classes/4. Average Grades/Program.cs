using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Average_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            int members = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();
            for (int i = 1; i <= members; i++)
            {
                Student newStudent = ReadStudent();
                if (newStudent.AverageGrades >= 5.00)
                    students.Add(newStudent);
            }
            foreach (var student in students.OrderBy(x => x.Name).ThenByDescending(x => x.AverageGrades))
            {
                Console.WriteLine($"{student.Name} -> {student.AverageGrades:f2}");
            }
        }
        private static Student ReadStudent()
        {
            List<string> input = Console.ReadLine().Split(' ').ToList();
            string name = input[0];
            input.RemoveAt(0);
            List<double> numbers = input.Select(x => double.Parse(x)).ToList();
            Student current = new Student() { Name = name, Grades = numbers };
            return current;
        }
    }

    class Student
    {
        public string Name { get; set; }
        public List<double> Grades { get; set; }
        public double AverageGrades { get { return Grades.Average(); } }
    }
}
