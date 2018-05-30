﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class EarthBender : Bender
{
    private double groundSaturation;

    public EarthBender(string name, int power, double groundSaturation)
        : base(name, power)
    {
        this.GroundSaturation = groundSaturation;
    }

    public double GroundSaturation
    {
        get { return groundSaturation; }
        private set { groundSaturation = value; }
    }

    public override double TotalPower => this.Power * this.GroundSaturation;

    public override string ToString()
    {
        return $"###Earth Bender: {this.Name}, Power: {this.Power}, Ground Saturation: {this.GroundSaturation:f2}";
    }
}

