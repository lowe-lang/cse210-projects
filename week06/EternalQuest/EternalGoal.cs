// EternalGoal.cs
public class EternalGoal : Goal
{
    public EternalGoal(string title, string description, int points)
        : base(title, description, points)
    {
    }

    public override int RecordEvent()
    {
        // always awards points; never completes
        return GetPoints();
    }

    public override string GetStringRepresentation()
    {
        // EternalGoal:Title,Description,Points
        return $"EternalGoal:{GetTitle()},{GetDescription()},{GetPoints()}";
    }

    // Use default status symbol (space) or override if desired
}
