using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(
        string name,
        string description,
        int points,
        int target,
        int bonus)
        : base(name, description, points)
    {
        if (target <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(target));
        }

        if (bonus < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(bonus));
        }

        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    public ChecklistGoal(
        string name,
        string description,
        int points,
        int target,
        int bonus,
        int completed)
        : base(name, description, points)
    {
        if (target <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(target));
        }

        if (bonus < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(bonus));
        }

        if (completed < 0 || completed > target)
        {
            throw new ArgumentOutOfRangeException(nameof(completed));
        }

        _target = target;
        _bonus = bonus;
        _amountCompleted = completed;
    }

    public override int RecordEvent()
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;

            if (_amountCompleted == _target)
            {
                return Points + _bonus;
            }

            return Points;
        }

        return 0;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        return $"[{(IsComplete() ? "X" : " ")}] {Name} ({Description}) -- Completed {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{EncodeField(Name)}|{EncodeField(Description)}|{Points}|{_target}|{_bonus}|{_amountCompleted}";
    }
}