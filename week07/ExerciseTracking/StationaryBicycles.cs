public class StationaryBicycles : Activity
{
    private double _speed; // in mph

    public StationaryBicycles(DateTime date, int minutes, double speed) 
        : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        // Distance = speed * (minutes / 60)
        return _speed * (GetMinutes() / 60.0);
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        // Pace = 60 / speed
        return 60.0 / _speed;
    }
}