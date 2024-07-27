public class SimpleGoal : Goal
{
    public bool IsCompleted { get; set; } // completed

    public SimpleGoal() { } // default constructor

    public SimpleGoal(string name, string description, int points, bool isCompleted)
        : base(name, description, points)
    {
        IsCompleted = isCompleted;
    }

    public override void RecordEvent()
    {
        IsCompleted = true; // mark complete
        IsComplete = true; // mark base complete
    }

    public override string SaveGoal()
    {
        return $"SimpleGoal:{Name},{Description},{Points},{IsCompleted}"; // save format
    }

    public override void LoadGoal(string[] parts)
    {
        if (parts.Length < 4) // check length
            throw new FormatException("Invalid data format.");

        Name = parts[1];
        Description = parts[2];
        Points = int.Parse(parts[3]);
        IsCompleted = bool.Parse(parts[4]);
    }
}
