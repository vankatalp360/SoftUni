using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF___4.Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int NumberOfPersons = int.Parse(Console.ReadLine());
            int ElevatorCapacity = int.Parse(Console.ReadLine());
            //if (NumberOfPersons % ElevatorCapacity==0) Console.WriteLine(NumberOfPersons / ElevatorCapacity);
            //else Console.WriteLine(NumberOfPersons/ ElevatorCapacity+1);
            int NumberOfLift = (int)Math.Ceiling((decimal)NumberOfPersons / ElevatorCapacity);
            Console.WriteLine(NumberOfLift);
        }
    }
}
