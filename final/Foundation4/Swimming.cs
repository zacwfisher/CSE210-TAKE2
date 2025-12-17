using System;

public class Swimming : Activity
{
    private int _laps;

    public Swimming(string date, int minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance() => _laps * 0.05;
    public override double GetSpeed() => GetDistance() / (_minutes / 60.0);
    public override double GetPace() => _minutes / GetDistance();
}