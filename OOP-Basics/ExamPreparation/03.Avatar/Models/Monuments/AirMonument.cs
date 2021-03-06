﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class AirMonument:Monument
{
    private int airAffinity;

    public AirMonument(string name, int airAffinity)
        : base(name)
    {
        this.AirAffinity = airAffinity;
    }

    public int AirAffinity
    {
        get { return airAffinity; }
        private set { airAffinity = value; }
    }

    public override string ToString()
    {
        return $"###Air Monument: {this.Name}, Air Affinity: {this.AirAffinity}";
    }

    public override int Affinity => this.AirAffinity;
}

