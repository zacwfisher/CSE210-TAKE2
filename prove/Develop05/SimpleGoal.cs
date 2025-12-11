using System;

class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        if (!IsComplete)
        {
            MarkComplete();
            return Points;
        }
        return 0;
    }

    public override string Serialize()
    {
        return $"SimpleGoal:{Name},{Description},{Points},{IsComplete}";
    }

    public static SimpleGoal CreateFromString(string[] parts)
    {
        var goal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
        if (bool.Parse(parts[4]))
        {
            goal.MarkComplete();
        }
        return goal;
    }
}