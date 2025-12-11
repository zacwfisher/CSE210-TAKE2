using System;

class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _currentCount = 0;
        _bonusPoints = bonusPoints;
    }

    public override int RecordEvent()
    {
        if (!IsComplete) return 0;
        
        _currentCount++;
        int totalPoints = Points;

        if (_currentCount >= _targetCount)
        {
            MarkComplete();
            totalPoints += _bonusPoints;
        }
        return totalPoints;
    }

    public override string GetStatus()
    {
        string baseStatus = base.GetStatus();
        return $"{baseStatus} -- Completed {_currentCount}/{_targetCount} times";
    }

    public override string Serialize()
    {
        return $"ChecklistGoal:{Name},{Description},{Points},{_targetCount},{_currentCount},{_bonusPoints},{IsComplete}";
    }

    public static ChecklistGoal CreateFromString(string[] parts)
    {
        var goal = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[6]));
        goal._currentCount = int.Parse(parts[5]);
        if (bool.Parse(parts[7]))
        {
            goal.MarkComplete();
        }
        return goal;
    }
}