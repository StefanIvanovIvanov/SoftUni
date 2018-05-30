public abstract class Provider : Entity, IProvider
{
    public double EnergyOutput { get; protected set; }
    public double Durability { get; protected set; }

    private const double startingDurability = 1000;

    protected Provider(int id, double energyOutput)
        : base(id)
    {
        this.EnergyOutput = energyOutput;
        this.Durability = startingDurability;
    }


    public void Repair(double val)
    {
        throw new System.NotImplementedException();
    }

   
}