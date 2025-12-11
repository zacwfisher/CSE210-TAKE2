using System;

static class GoalFactory
{
    public static Goal FromString(string line)
    {
        var parts = line.Split('|');
        return parts[0] switch
        {
            "SimpleGoal" => SimpleGoal.CreateFromString(parts),
            "EternalGoal" => EternalGoal.CreateFromString(parts),
            "ChecklistGoal" => ChecklistGoal.CreateFromString(parts),
            _ => null
        };
    }
}