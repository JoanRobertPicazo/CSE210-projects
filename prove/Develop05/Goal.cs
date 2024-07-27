public abstract class Goal
{
    public string Name { get; set; } // name
    public string Description { get; set; } // description
    public int Points { get; set; } // points
    public bool IsComplete { get; set; } // complete

    protected Goal() { } // default constructor

    protected Goal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
        IsComplete = false; // not complete
    }

    public abstract void RecordEvent();
    public abstract string SaveGoal();
    public abstract void LoadGoal(string[] parts);
}
