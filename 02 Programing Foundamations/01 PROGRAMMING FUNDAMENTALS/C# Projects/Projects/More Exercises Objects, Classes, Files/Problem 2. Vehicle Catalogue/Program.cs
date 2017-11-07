using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> venicheCatalogue = new List<Vehicle>();
            while (true)
            {
                string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (input[0] == "End") break;
                AddVehiches(venicheCatalogue, input);
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Close the Catalogue") break;
                PrintModelCharacteristics(venicheCatalogue, input);
            }
            PrintAverageHorsepowers(venicheCatalogue);
        }

        private static void PrintAverageHorsepowers(List<Vehicle> venicheCatalogue)
        {
            double carHorsepower = 0;
            double truckHorsepower = 0;
            if (venicheCatalogue.Any(x => x.Type == "Car"))
            {
                carHorsepower = venicheCatalogue.Where(x => x.Type == "Car").Select(x => x.Horsepower).Average();
            }
            Console.WriteLine($"{"Cars"} have average horsepower of: {carHorsepower:f2}.");
            if (venicheCatalogue.Any(x => x.Type == "Truck"))
            {
                truckHorsepower = venicheCatalogue.Where(x => x.Type == "Truck").Select(x => x.Horsepower).Average();
            }
            Console.WriteLine($"{"Trucks"} have average horsepower of: {truckHorsepower:f2}.");
        }

        private static void PrintModelCharacteristics(List<Vehicle> venicheCatalogue, string input)
        {
            List<Vehicle> currentVehiche = venicheCatalogue.Where(x => x.Model == input).ToList();
            foreach (var current in currentVehiche)
            {
                Console.WriteLine($"Type: {current.Type}");
                Console.WriteLine($"Model: {current.Model}");
                Console.WriteLine($"Color: {current.Color}");
                Console.WriteLine($"Horsepower: {current.Horsepower}");
            }
        }

        private static void AddVehiches(List<Vehicle> venicheCatalogue, string[] input)
        {
            Vehicle currentVehiche = new Vehicle();
            string type = input[0].ToLower();
            if (type == "car") currentVehiche.Type = "Car";
            else if (type == "truck") currentVehiche.Type = "Truck";
            currentVehiche.Model = input[1];
            currentVehiche.Color = input[2];
            currentVehiche.Horsepower = int.Parse(input[3]);
            venicheCatalogue.Add(currentVehiche);
        }
    }
    class Vehicle
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Horsepower { get; set; }
    }
}
