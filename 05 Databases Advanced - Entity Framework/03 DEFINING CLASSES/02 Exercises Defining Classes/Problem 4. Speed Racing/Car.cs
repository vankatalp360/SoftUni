using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Car
{
    public string Model { get; set; }
    public double FuelAmmount { get; set; }
    public double FuelConsumption { get; set; }
    public double DistanceTraveled { get; set; }

    public Car()
    {
        this.DistanceTraveled = 0;
    }

    public Car(string model , double fuelAmmount, double fuelConsumption)
    {
        this.Model = model;
        this.FuelAmmount = fuelAmmount;
        this.FuelConsumption = fuelConsumption;
    }

    public bool MoveCar(double amountOfKm)
    {
        double fuelNeeded = amountOfKm * this.FuelConsumption;
        if(this.FuelAmmount<fuelNeeded)
        {
            return false;
        }
        this.FuelAmmount -= fuelNeeded;
        this.DistanceTraveled += amountOfKm;
        return true;
    }

    public override string ToString()
    {
        return $"{this.Model} {this.FuelAmmount:f2} {this.DistanceTraveled}";
    }
}