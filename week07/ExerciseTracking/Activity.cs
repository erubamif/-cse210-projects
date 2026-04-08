using System;

public abstract class Activity
{
    private DateTime _date;
    private int _minutes;

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public DateTime GetDate() => _date;
    public int GetMinutes() => _minutes;

    // Abstract methods - must be overridden by derived classes
    public abstract double GetDistance();  // miles or km
    public abstract double GetSpeed();     // mph or kph
    public abstract double GetPace();      // min per mile or min per km

    // Virtual method - can be overridden but default implementation works
    public virtual string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {GetType().Name} ({_minutes} min) - " +
               $"Distance: {GetDistance():F1} miles, " +
               $"Speed: {GetSpeed():F1} mph, " +
               $"Pace: {GetPace():F1} min per mile";
    }
}