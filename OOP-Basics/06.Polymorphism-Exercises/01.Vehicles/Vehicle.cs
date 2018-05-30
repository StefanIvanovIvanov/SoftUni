using System;


public abstract class Vehicle
{
    private double fuelQuantity;
    private double litersPerKm;

    public Vehicle(double fuelQuantity, double litersPerKm)
    {
        this.FuelQuantity = fuelQuantity;
        this.LitersPerKm = litersPerKm;
    }

    public double FuelQuantity
    {
        get { return this.fuelQuantity; }
        set { this.fuelQuantity = value; }
    }

    public double LitersPerKm
    {
        get { return this.litersPerKm; }
        set { this.litersPerKm = value; }
    }

    public void Drive(double travelledKm)
    {
        double neededFuel = travelledKm * this.LitersPerKm;
        if (this.FuelQuantity < neededFuel)
        {
            throw new ArgumentException($"{GetType()} needs refueling");
        }
        this.FuelQuantity -= neededFuel;
        Console.WriteLine($"{this.GetType()} travelled {travelledKm} km");
    }

    public virtual void Refuel(double fuel)
    {
        this.FuelQuantity += fuel;
    }

    public override string ToString()
    {
        return $"{this.GetType()}: {this.FuelQuantity:f2}";
    }
}

