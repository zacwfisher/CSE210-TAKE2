using System;

class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        return Points;
    }

    public override string Serialize()
    {
        return $"EternalGoal:{Name},{Description},{Points}";
    }

    public static EternalGoal CreateFromString(string[] parts)
    {
        return new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
    }
}