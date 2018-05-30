using System;
using System.Collections.Generic;
using System.Text;


public class Car
{
    private string model;

    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }

    private Engine engine;

    public Engine Engine
    {
        get { return this.engine; }
        set { this.engine = value; }
    }

    private Cargo cargo;

    public Cargo Cargo
    {
        get { return this.cargo; }
        set { this.cargo = value; }
    }

    private List<Tire> tires;

    public List<Tire> Tires
    {
        get { return this.tires; }
        set { this.tires = value; }
    }


        public Car(string model, Engine engine, Cargo cargo, List<Tire>tires)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;        
            this.Tires =  tires;
        }
        
    

}

