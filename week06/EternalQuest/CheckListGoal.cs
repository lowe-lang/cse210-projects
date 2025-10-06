// ChecklistGoal.cs
public class ChecklistGoal : Goal
{
    private int _requiredCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string title, string description, int points, int requiredCount, int bonusPoints, int currentCount = 0)
        : base(title, description, points)
    {
        _requiredCount = requiredCount;
        _bonusPoints = bonusPoints;
        _currentCount = currentCount;
    }

    public override int RecordEvent()
    {
        if (_currentCount < _requiredCount)
        {
            _currentCount++;
            if (_currentCount == _requiredCount)
            {
                // completed now — award points for this occurrence plus bonus
                return GetPoints() + _bonusPoints;
            }
            return GetPoints();
        }
        return 0;
    }

    protected override string GetStatusSymbol() => _currentCount >= _requiredCount ? "X" : " ";

    public override string GetDetailsString()
    {
        return $"[{GetStatusSymbol()}] {GetTitle()} ({GetDescription()}) -- Completed {_currentCount}/{_requiredCount}";
    }

    public override string GetStringRepresentation()
    {
        // ChecklistGoal:Title,Description,Points,requiredCount,currentCount,bonus
        return $"ChecklistGoal:{GetTitle()},{GetDescription()},{GetPoints()},{_requiredCount},{_currentCount},{_bonusPoints}";
    }
}
