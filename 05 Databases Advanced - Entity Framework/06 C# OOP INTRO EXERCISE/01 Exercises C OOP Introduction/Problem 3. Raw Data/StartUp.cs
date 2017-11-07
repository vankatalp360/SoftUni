using System;
using System.Collections.Generic;

namespace Problem_3.Raw_Data
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for(int i =1; i <= n;i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string model = tokens[0];
                int engineSpeed = int.Parse(tokens[1]);
                int enginePower = int.Parse(tokens[2]);
                Engine engine = new Engine(engineSpeed, enginePower);
                int cargoWeight = int.Parse(tokens[3]);
                string cargoType = tokens[4];
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                List<Tire> tires = new List<Tire>();
                for(int j = 5; j<13;j+=2)
                {
                    double tirePressure = double.Parse(tokens[j]);
                    int tireAge = int.Parse(tokens[j+1]);
                    Tire tire = new Tire(tirePressure, tireAge);
                    tires.Add(tire);
                }
                Car car = new Car(model, engine, cargo, tires.ToArray());
                cars.Add(car);
            }
            string command = Console.ReadLine();
            switch(command)
            {
                case "fragile":
                    PrintResultFirstType(cars);
                    break;
                case "flammable":
                    PrintResultSecondType(cars);

                    break;
            }
        }

        private static void PrintResultSecondType(List<Car> cars)
        {
            foreach (var car in cars.FindAll(c => c.Cargo.CargoType == "flammable" && c.Engine.EnginePower>250))
            {
                Console.WriteLine(car);
            }
        }

        private static void PrintResultFirstType(List<Car> cars)
        {
            foreach(var car in cars.FindAll(c=>c.Cargo.CargoType== "fragile"))
            {
                bool result = false;
                foreach(var tire in car.Tires)
                {
                    if (tire.TirePressure<1)
                    {
                        result = true;
                        break;
                    }
                }
                if(result)
                {
                    Console.WriteLine(car);
                }
            }
        }
    }
}
