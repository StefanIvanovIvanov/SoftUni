
public class DragRace : Race
{
    public DragRace(int length, string route, int prizePool) : base(length, route, prizePool)
    {
    }

    protected override int GetPerformancePoints(Car car) => car.HorsePower / car.Acceleration;
}