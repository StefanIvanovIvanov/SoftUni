using System;
using System.Collections.Generic;
using System.Text;


public class Car : Vehicle
{
    public Car(double fuelQuantity, double litersPerKm)
        : base(fuelQuantity, litersPerKm)
    {
        base.LitersPerKm = litersPerKm + 0.9;
    }
}

