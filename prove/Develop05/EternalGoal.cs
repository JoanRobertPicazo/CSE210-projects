public class EternalGoal : Goal
{
    public EternalGoal() { } // default constructor

    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override void RecordEvent()
    {
        Points += 100; // add points
    }

    public override string SaveGoal()
    {
        return $"EternalGoal:{Name},{Description},{Points}"; // save format
    }

    public override void LoadGoal(string[] parts)
    {
        if (parts.Length < 4) // check length
            throw new FormatException("Invalid data format.");

        Name = parts[1];
        Description = parts[2];
        Points = int.Parse(parts[3]);
    }
}
