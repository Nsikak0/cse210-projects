using System;

public class Swimming : Activity
{
    private readonly int _laps;

    public Swimming(DateTime date, int minutes, int laps)
        : base(date, minutes)
    {
        if (laps <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(laps), "Swimming laps must be greater than zero.");
        }

        _laps = laps;
    }

    public override double GetDistance()
    {
        return (_laps * 50) / 1000.0;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / GetMinutes()) * 60;
    }

    public override double GetPace()
    {
        return GetMinutes() / GetDistance();
    }
}