// SimpleGoal.cs
public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string title, string description, int points, bool isComplete = false)
        : base(title, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return GetPoints();
        }
        return 0;
    }

    protected override string GetStatusSymbol() => _isComplete ? "X" : " ";

    public override string GetStringRepresentation()
    {
        // SimpleGoal:Title,Description,Points,isComplete
        return $"SimpleGoal:{GetTitle()},{GetDescription()},{GetPoints()},{_isComplete}";
    }
}
