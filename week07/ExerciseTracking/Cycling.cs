using System;

public class Cycling : Activity
{
    private readonly double _speed;

    public Cycling(DateTime date, int minutes, double speed)
        : base(date, minutes)
    {
        if (speed <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(speed), "Cycling speed must be greater than zero.");
        }

        _speed = speed;
    }

    public override double GetDistance()
    {
        return (_speed * GetMinutes()) / 60;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return 60 / _speed;
    }
}