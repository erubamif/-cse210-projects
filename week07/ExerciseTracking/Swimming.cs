public class Swimming : Activity
{
    private int _laps;
    private const double LAP_LENGTH_METERS = 50;
    private const double METERS_TO_MILES = 0.000621371;

    public Swimming(DateTime date, int minutes, int laps) 
        : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        // Distance (miles) = laps * 50 / 1000 * 0.62
        double distanceKm = (_laps * LAP_LENGTH_METERS) / 1000.0;
        return distanceKm * METERS_TO_MILES;
    }

    public override double GetSpeed()
    {
        // Speed = distance / minutes * 60
        return (GetDistance() / GetMinutes()) * 60;
    }

    public override double GetPace()
    {
        // Pace = minutes / distance
        return GetMinutes() / GetDistance();
    }
}