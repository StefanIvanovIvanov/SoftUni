﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class WaterMonument : Monument
{
    private int waterAffinity;

    public WaterMonument(string name, int waterAffinity)
        : base(name)
    {
        this.WaterAffinity = waterAffinity;
    }

    public int WaterAffinity
    {
        get { return waterAffinity; }
        private set { waterAffinity = value; }
    }

    public override string ToString()
    {
        return $"###Water Monument: {this.Name}, Water Affinity: {this.WaterAffinity}";
    }

    public override int Affinity => this.WaterAffinity;
}
