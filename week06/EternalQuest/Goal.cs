// Goal.cs
using System;

public abstract class Goal
{
    private string _title;
    private string _description;
    private int _points;

    public Goal(string title, string description, int points)
    {
        _title = title;
        _description = description;
        _points = points;
    }

    public string GetTitle() => _title;
    public string GetDescription() => _description;
    public int GetPoints() => _points;

    // RecordEvent returns points gained by this record action.
    public abstract int RecordEvent();

    // Human readable details (override if more info needed)
    public virtual string GetDetailsString()
    {
        return $"[{GetStatusSymbol()}] {GetTitle()} ({GetDescription()})";
    }

    // Status symbol used in listing - default for base classes that may override
    protected virtual string GetStatusSymbol()
    {
        return " ";
    }

    // Return a line that can be saved to file and later parsed.
    public abstract string GetStringRepresentation();
}
