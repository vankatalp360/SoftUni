using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace More_Exercises_Objects__Classes__Files
{
    class Program
    {
        static void Main(string[] args)
        {
            List<People> peoples = new List<People>();
            while(true)
            {
                string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (input[0] == "End") break;
                AddPeorson(peoples, input);
            }
            PrintResult(peoples);
        }

        private static void PrintResult(List<People> peoples)
        {
            foreach(var person in peoples.OrderBy(x=>x.Age))
            {
                Console.WriteLine($"{person.Name} with ID: {person.ID} is {person.Age} years old.");
            }
        }

        private static void AddPeorson(List<People> peoples, string[] input)
        {
            People currentPeorson = new People();
            currentPeorson.Name = input[0];
            currentPeorson.ID = input[1];
            currentPeorson.Age = int.Parse(input[2]);
            peoples.Add(currentPeorson);
        }
    }
    class People
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }
    }
}
