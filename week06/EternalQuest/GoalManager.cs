using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private readonly List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public int GetScore()
    {
        return _score;
    }

    public int GetLevel()
    {
        return (_score / 1000) + 1;
    }

    public void AddGoal(Goal goal)
    {
        ArgumentNullException.ThrowIfNull(goal);
        _goals.Add(goal);
    }

    public void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void RecordEvent(int index)
    {
        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        int points = _goals[index].RecordEvent();

        _score += points;

        Console.WriteLine($"You earned {points} points!");
        Console.WriteLine($"Current score: {_score}");
    }

    public void SaveGoals(string fileName)
    {
        if (string.IsNullOrWhiteSpace(fileName))
        {
            Console.WriteLine("A filename is required.");
            return;
        }

        try
        {
            using (StreamWriter output = new StreamWriter(fileName))
            {
                output.WriteLine(_score);

                foreach (Goal goal in _goals)
                {
                    output.WriteLine(goal.GetStringRepresentation());
                }
            }

            Console.WriteLine("Goals saved successfully.");
        }
        catch (Exception ex) when (ex is IOException ||
                                   ex is UnauthorizedAccessException ||
                                   ex is ArgumentException ||
                                   ex is NotSupportedException)
        {
            Console.WriteLine($"Could not save goals: {ex.Message}");
        }
    }

    public void LoadGoals(string fileName)
    {
        if (string.IsNullOrWhiteSpace(fileName))
        {
            Console.WriteLine("A filename is required.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(fileName);
            if (lines.Length == 0 ||
                !int.TryParse(lines[0], out int loadedScore) ||
                loadedScore < 0)
            {
                throw new FormatException("The file does not contain a valid score.");
            }

            List<Goal> loadedGoals = new List<Goal>();
            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                {
                    continue;
                }

                loadedGoals.Add(ParseGoal(lines[i]));
            }

            _goals.Clear();
            _goals.AddRange(loadedGoals);
            _score = loadedScore;
            Console.WriteLine("Goals loaded successfully.");
        }
        catch (Exception ex) when (ex is IOException ||
                                   ex is UnauthorizedAccessException ||
                                   ex is ArgumentException ||
                                   ex is NotSupportedException ||
                                   ex is FormatException ||
                                   ex is OverflowException)
        {
            Console.WriteLine($"Could not load goals: {ex.Message}");
        }
    }

    private static Goal ParseGoal(string line)
    {
        string[] parts = line.Split('|');
        try
        {
            return parts[0] switch
            {
                "SimpleGoal" when parts.Length == 5 =>
                    new SimpleGoal(
                        DecodeField(parts[1]),
                        DecodeField(parts[2]),
                        int.Parse(parts[3]),
                        bool.Parse(parts[4])),
                "EternalGoal" when parts.Length == 4 =>
                    new EternalGoal(
                        DecodeField(parts[1]),
                        DecodeField(parts[2]),
                        int.Parse(parts[3])),
                "ChecklistGoal" when parts.Length == 7 =>
                    new ChecklistGoal(
                        DecodeField(parts[1]),
                        DecodeField(parts[2]),
                        int.Parse(parts[3]),
                        int.Parse(parts[4]),
                        int.Parse(parts[5]),
                        int.Parse(parts[6])),
                _ => throw new FormatException("A goal record has an unknown type or invalid field count.")
            };
        }
        catch (FormatException ex)
        {
            throw new FormatException("A goal record contains invalid data.", ex);
        }
    }

    private static string DecodeField(string value)
    {
        return value.Replace("%0A", "\n")
                    .Replace("%0D", "\r")
                    .Replace("%7C", "|")
                    .Replace("%25", "%");
    }
}