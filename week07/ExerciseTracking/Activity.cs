using System;
using System.Globalization;

public abstract class Activity
{
    private readonly DateTime _date;
    private readonly int _minutes;

    public Activity(DateTime date, int minutes)
    {
        if (minutes <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(minutes), "Activity duration must be greater than zero.");
        }

        _date = date;
        _minutes = minutes;
    }

    public DateTime GetDate()
    {
        return _date;
    }

    public int GetMinutes()
    {
        return _minutes;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public string GetSummary()
    {
        return string.Format(
            CultureInfo.InvariantCulture,
            "{0:dd MMM yyyy} {1} ({2} min): Distance {3:F1} km, Speed {4:F1} kph, Pace {5:F2} min per km",
            _date,
            GetType().Name,
            _minutes,
            GetDistance(),
            GetSpeed(),
            GetPace());
    }
}