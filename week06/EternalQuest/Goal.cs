using System;

public abstract class Goal
{
    private readonly string _name;
    private readonly string _description;
    private readonly int _points;

    protected string Name => _name;
    protected string Description => _description;
    protected int Points => _points;

    public Goal(string name, string description, int points)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(description);
        if (points < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(points));
        }

        _name = name;
        _description = description;
        _points = points;
    }

    public string GetName()
    {
        return _name;
    }

    public abstract int RecordEvent();

    public abstract bool IsComplete();

    public abstract string GetDetailsString();

    public abstract string GetStringRepresentation();

    protected static string EncodeField(string value)
    {
        return value.Replace("%", "%25")
                    .Replace("|", "%7C")
                    .Replace("\r", "%0D")
                    .Replace("\n", "%0A");
    }
}