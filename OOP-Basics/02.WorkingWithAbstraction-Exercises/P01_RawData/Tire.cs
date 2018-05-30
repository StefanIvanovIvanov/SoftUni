using System;
using System.Collections.Generic;
using System.Text;


public class Tire
{
    private double tirePressure;
    private int tireAge;

    public double TirePressure
    {
        get { return tirePressure; }
        set { tirePressure = value; }
    }

    public int TireAge
    {
        get { return tireAge; }
        set { tireAge = value; }
    }

    public Tire(double presure, int age)
    {
        this.TirePressure = presure;
        this.TireAge = age;
    }
}

