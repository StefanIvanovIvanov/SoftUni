using System;
using System.Collections.Generic;
using System.Text;

public class Truck : Vehicle
{

    public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
        : base(fuelQuantity, fuelConsumption, tankCapacity)
    {
    }

    protected override double AdditionalConsumption => 1.6;

    public override void Refuel(double fuel)
    {
        base.Refuel(fuel);
        this.FuelQuantity -= (1 - 0.95) * fuel;
    }
}