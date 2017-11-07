using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StartUp
{
    static void Main(string[] args)
    {
        double n = double.Parse(Console.ReadLine());
        List<Car> cars = new List<Car>();
        for (double i = 1; i<= n; i++)
        {
            string[] input = Console.ReadLine().Split(' ').ToArray();
            string model = input[0];
            double fuelAmmount = double.Parse(input[1]);
            double fuelConsumption = double.Parse(input[2]);
            if(!cars.Any(x=>x.Model==model) )
            {
                Car currentCar = new Car(model, fuelAmmount, fuelConsumption);
                cars.Add(currentCar);
            }            
        }
        string commands;
        while ((commands=Console.ReadLine()) != "End")
        {
            string[] cmdAgrs = commands.Split(' ').ToArray();
            string CarModel = cmdAgrs[1];
            double amountOfKm = double.Parse(cmdAgrs[2]);

            Car car = cars.First(x => x.Model == CarModel);
            bool IsMoved = car.MoveCar(amountOfKm);
            if(!IsMoved)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
        foreach(var car in cars)
        {
            Console.WriteLine(car);
        }
    }
} 