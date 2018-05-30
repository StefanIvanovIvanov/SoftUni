public class CasualRace : Race
{
    public CasualRace(int length, string route, int prizePool) : base(length, route, prizePool)
    {
    }

    protected override int GetPerformancePoints(Car car)
        => (car.HorsePower / car.Acceleration) + (car.Suspension + car.Durability);
}