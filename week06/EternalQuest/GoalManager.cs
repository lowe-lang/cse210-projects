// GoalManager.cs
using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void AddGoal(Goal g) => _goals.Add(g);

    public void ListGoals()
    {
        Console.WriteLine("Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i+1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void ShowScore()
    {
        Console.WriteLine($"Your score: {_score}");
    }

    public void RecordEvent(int index)
    {
        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }
        int gained = _goals[index].RecordEvent();
        _score += gained;
        Console.WriteLine($"You earned {gained} points!");
    }

    // Save to file
    public void Save(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine($"SCORE:{_score}");
            foreach (var g in _goals)
            {
                writer.WriteLine(g.GetStringRepresentation());
            }
        }
        Console.WriteLine($"Saved to {filename}");
    }

    // Load from file
    public void Load(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _goals.Clear();
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            if (line.StartsWith("SCORE:"))
            {
                int.TryParse(line.Substring(6), out _score);
            }
            else
            {
                // use factory to create Goal from string
                var g = CreateGoalFromString(line);
                if (g != null) _goals.Add(g);
            }
        }
        Console.WriteLine($"Loaded from {filename}");
    }

    // A small factory
    private Goal CreateGoalFromString(string line)
    {
        // Format: Type:data
        var parts = line.Split(':', 2);
        if (parts.Length < 2) return null;
        string type = parts[0];
        string data = parts[1];
        var fields = data.Split(',');

        try
        {
            switch (type)
            {
                case "SimpleGoal":
                    // Title,Description,Points,isComplete
                    return new SimpleGoal(fields[0], fields[1], int.Parse(fields[2]), bool.Parse(fields[3]));
                case "EternalGoal":
                    // Title,Description,Points
                    return new EternalGoal(fields[0], fields[1], int.Parse(fields[2]));
                case "ChecklistGoal":
                    // Title,Description,Points,requiredCount,currentCount,bonus
                    return new ChecklistGoal(fields[0], fields[1], int.Parse(fields[2]),
                                             int.Parse(fields[3]), int.Parse(fields[5]), int.Parse(fields[4]));
                default:
                    return null;
            }
        }
        catch
        {
            // parsing error
            return null;
        }
    }
}
