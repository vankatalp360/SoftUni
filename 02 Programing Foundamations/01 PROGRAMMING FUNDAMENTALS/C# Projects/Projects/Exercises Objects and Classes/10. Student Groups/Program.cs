using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace _10.Student_Groups
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Town> townsAndStudents = ReadTownsAndStudents();
            List<Town> orderedTown = OrderTheTowns(townsAndStudents);
            //townsAndStudents = townsAndStudents.Select(x=>x.Students.OrderBy(s => s.RegistrationDate).ThenBy(s => s.Name).ThenBy(s => s.Email).ToList()).ToList();
            List<Group> groups = DistributeStudentsIntoGroups(orderedTown);
            PrintGroups(groups, townsAndStudents);
        }

        private static List<Town> OrderTheTowns(List<Town> townsAndStudents)
        {
            List<Town> orderedTown = new List<Town>();
            foreach (var town in townsAndStudents)
            {
                List<Student> students = town.Students.OrderBy(x => x.RegistrationDate).ThenBy(x => x.Name).ThenBy(x => x.Email).ToList();
                Town currentTown = new Town();
                currentTown.Name = town.Name;
                currentTown.SeatsCount = town.SeatsCount;
                currentTown.Students = students;
                orderedTown.Add(currentTown);
            }

            return orderedTown;
        }

        private static void PrintGroups(List<Group> groups, List<Town> towns)
        {
            Console.WriteLine($"Created {groups.Count} groups in {towns.Count} towns:");
            foreach (var group in groups.OrderBy(x => x.Town.Name))
            {
                Console.WriteLine($"{group.Town.Name} => {string.Join(", ", group.Students.Select(x => x.Email).ToList())}");
            }
        }

        private static List<Town> ReadTownsAndStudents()
        {
            List<Town> towns = new List<Town>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End") break;
                bool townAppeared;
                Match match;
                CheckIfTownAppeared(input, out townAppeared, out match);
                if (townAppeared)
                {
                    CreateTowns(towns, match);
                }
                else
                {
                    AddStudentsInTheTown(towns, input);
                }
            }
            return towns;
        }

        private static List<Group> DistributeStudentsIntoGroups(List<Town> towns)
        {
            List<Group> groups = new List<Group>();
            foreach (var town in towns)
            {
                List<Student> students = town.Students;
                int seats = town.SeatsCount;
                int count;
                if (students.Count % town.SeatsCount > 0)
                    count = students.Count / town.SeatsCount;
                else
                    count = students.Count / town.SeatsCount - 1;
                for (int i = 0; i <= count; i++)
                {
                    Group group = new Group();
                    List<Student> studentsInCurrentGroup = students.Skip(i * seats).Take(seats).ToList();
                    group.Students = studentsInCurrentGroup;
                    group.Town = town;
                    groups.Add(group);
                }
            }
            return groups;
        }

        private static void AddStudentsInTheTown(List<Town> towns, string input)
        {
            string[] inputs = input.Split('|').Select(x => x.Trim()).ToArray();
            Student newStudent = new Student();
            newStudent.Name = inputs[0];
            newStudent.Email = inputs[1];
            newStudent.RegistrationDate = DateTime.ParseExact(inputs[2], "d-MMM-yyyy", CultureInfo.InvariantCulture);
            towns[towns.Count - 1].Students.Add(newStudent);
        }

        private static void CreateTowns(List<Town> towns, Match match)
        {
            string townName = match.Groups[1].ToString().Trim();
            string[] seats = match.Groups[2].ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            int seatsCount = int.Parse(seats[0]);
            Town newTown = new Town();
            newTown.Name = townName;
            newTown.SeatsCount = seatsCount;
            newTown.Students = new List<Student>();
            towns.Add(newTown);
        }

        private static void CheckIfTownAppeared(string input, out bool townAppeared, out Match match)
        {
            townAppeared = false;
            string pattern = @"(.*)=>(.*)";
            Regex regex = new Regex(pattern);
            match = regex.Match(input);
            if (match.Groups.Count > 1) townAppeared = true;
        }

    }
    class Student
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
    class Town
    {
        public string Name { get; set; }
        public int SeatsCount { get; set; }
        public List<Student> Students { get; set; }
    }
    class Group
    {
        public Town Town { get; set; }
        public List<Student> Students { get; set; }
    }
}
