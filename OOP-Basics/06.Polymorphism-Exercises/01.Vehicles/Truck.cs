using System;
using System.Collections.Generic;
using System.Text;


public class Truck : Vehicle
{
    public Truck(double fuelQuantity, double litersPerKm)
        : base(fuelQuantity, litersPerKm)
    {
        base.LitersPerKm = litersPerKm + 1.6;
    }

    public override void Refuel(double fuel)
    {
        fuel = fuel * 0.95;
        base.FuelQuantity += fuel;
    }
}

