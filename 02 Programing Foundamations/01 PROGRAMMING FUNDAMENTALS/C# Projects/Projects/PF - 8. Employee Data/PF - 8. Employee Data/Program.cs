using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___8.Employee_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            string FirstName = "Amanda";
            string LastName = "Jonson";
            int Age = 27;
            char Gender = 'f';
            long PersonalID = 8306112507;
            uint UniqueEmpNumber = 27563571;
            Console.WriteLine($"First name: {FirstName}");
            Console.WriteLine($"Last name: {LastName}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Gender: {Gender}");
            Console.WriteLine($"Personal ID: {PersonalID}");
            Console.WriteLine($"Unique Employee number: {UniqueEmpNumber}");
        }
    }
}
