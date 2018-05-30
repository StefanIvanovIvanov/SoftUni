using System;
using System.Text;


class Ferrari : IFerrari
{
    private string model = "488-Spider";
    private string driver;

    public Ferrari(string driver)
    {
        this.Driver = driver;
    }

    public string Driver
    {
        get { return this.driver; }
        set { this.driver = value; }
    }

    public string Brakes()
    {
        return "Brakes!";
    }

    public string GasPedal()
    {
        return "Zadu6avam sA!";
    }

    public override string ToString()
    {
        return $"{this.model}/{this.Brakes()}/{this.GasPedal()}/{this.Driver}";
    }
}

